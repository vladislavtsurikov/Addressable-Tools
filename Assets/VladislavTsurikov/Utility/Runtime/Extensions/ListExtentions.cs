﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Random = UnityEngine.Random;

namespace VladislavTsurikov.Utility.Runtime
{
    public static class ListExtensions
    {
        private static class ArrayAccessor<T>
        {
#if ENABLE_IL2CPP || NET_STANDARD_2_0
            public static readonly FieldInfo FieldInfo;
            public static readonly Func<List<T>, object> AotGetter;
#else
            public static readonly Func<List<T>, T[]> Getter;       
#endif
            static ArrayAccessor()
            {
#if ENABLE_IL2CPP || NET_STANDARD_2_0
                FieldInfo = typeof(List<T>).GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance);
                AotGetter = FieldInfo.GetValue;
#else
                // ReSharper disable once RedundantExplicitArrayCreation
                var dm = new DynamicMethod("get", MethodAttributes.Static | MethodAttributes.Public,
                    CallingConventions.Standard, typeof(T[]), new Type[] { typeof(List<T>) }, typeof(ArrayAccessor<T>),
                    true);
                var il = dm.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0); // Load List<T> argument
                // ReSharper disable once AssignNullToNotNullAttribute
                il.Emit(OpCodes.Ldfld,
                    typeof(List<T>).GetField("_items",
                        BindingFlags.NonPublic | BindingFlags.Instance)); // Replace argument by field
                il.Emit(OpCodes.Ret); // Return field
                Getter = (Func<List<T>, T[]>)dm.CreateDelegate(typeof(Func<List<T>, T[]>));
#endif
            }
        }

        public static T[] GetInternalArray<T>(this List<T> list)
        {
#if ENABLE_IL2CPP || NET_STANDARD_2_0
            return (T[])ArrayAccessor<T>.AotGetter(list);
#else
            return ArrayAccessor<T>.Getter(list);
#endif
        }
        
        public static T GetRandomItem<T>(this List<T> items)
        {
            if (items == null || items.Count == 0)
            {
                return default;
            }
            
            int randomIndex = Random.Range(0, items.Count);
            return items[randomIndex];
        }
    }
}
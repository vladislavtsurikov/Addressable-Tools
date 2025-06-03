using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Cysharp.Threading.Tasks;
using ModestTree;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace VladislavTsurikov.AddressableLoaderSystem.Runtime.Core
{
    internal static class AssetReferenceReflectionLoader
    {
        internal static async UniTask LoadAllAssetReferences(object target, ResourceLoader owner, CancellationToken token)
        {
            if (target == null)
            {
                return;
            }

            Type type = target.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(target);
                if (value == null)
                {
                    continue;
                }

                if (field.HasAttribute(typeof(IgnoreResourceAutoload)))
                {
                    continue;
                }

                if (value is Object uObj && uObj == null)
                {
                    continue;
                }

                if (typeof(AssetReference).IsAssignableFrom(field.FieldType) && value is AssetReference assetRef)
                {
                    if (assetRef.RuntimeKeyIsValid())
                    {
                        await LoadAndProcess(assetRef, field.FieldType, owner, token);
                    }
                    continue;
                }

                if (field.FieldType != typeof(string) && value is not Transform && value is IEnumerable enumerable)
                {
                    foreach (object element in enumerable)
                    {
                        if (element == null)
                        {
                            continue;
                        }

                        Type elementType = element.GetType();
                        if (elementType == null)
                        {
                            continue;
                        }

                        if (elementType.IsGenericType && elementType.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                        {
                            try
                            {
                                dynamic keyValuePair = element;
                                object rawValue = keyValuePair.Value;

                                if (rawValue is AssetReference castedValueRef)
                                {
                                    await LoadAndProcess(castedValueRef, castedValueRef.GetType(), owner, token);
                                }
                                else
                                {
                                    await LoadAllAssetReferences(rawValue, owner, token);
                                }
                            }
                            catch
                            {
                                // ignored
                            }

                            continue;
                        }

                        if (element is AssetReference elementRef)
                        {
                            await LoadAndProcess(elementRef, elementType, owner, token);
                        }
                        else
                        {
                            await LoadAllAssetReferences(element, owner, token);
                        }
                    }

                    continue;
                }

                if (!field.FieldType.IsPrimitive &&
                    field.FieldType != typeof(string) &&
                    !typeof(IEnumerable).IsAssignableFrom(field.FieldType) &&
                    !typeof(Object).IsAssignableFrom(field.FieldType))
                {
                    await LoadAllAssetReferences(value, owner, token);
                }
            }
        }
        
        private static async UniTask LoadAndProcess(AssetReference assetRef, Type declaredFieldType, ResourceLoader owner, CancellationToken cancellationToken)
        {
            Object result = await AddressableAssetTracker.TrackAndLoad<Object>(assetRef, owner, cancellationToken);

            if (IsGenericAssetReferenceOf(declaredFieldType, typeof(ScriptableObject)) && result is ScriptableObject so)
            {
                await LoadAllAssetReferences(so, owner, cancellationToken);
            }
            else if (IsGenericAssetReferenceOf(declaredFieldType, typeof(GameObject)) && result is GameObject go)
            {
                await LoadAssetReferencesRecursive(go, owner, cancellationToken);
            }
        }
        
        private static bool IsGenericAssetReferenceOf(Type declaredType, Type targetGeneric)
        {
            while (declaredType != null && declaredType != typeof(object))
            {
                if (declaredType.IsGenericType && declaredType.GetGenericTypeDefinition() == typeof(AssetReferenceT<>))
                {
                    Type genericArg = declaredType.GetGenericArguments()[0];
                    return targetGeneric.IsAssignableFrom(genericArg);
                }

                declaredType = declaredType.BaseType;
            }

            return false;
        }

        internal static async UniTask LoadAssetReferencesRecursive(object result, ResourceLoader owner, CancellationToken cancellationToken)
        {
            if (result is ScriptableObject so)
            {
                await LoadAllAssetReferences(so, owner, cancellationToken);
            }
            else if (result is GameObject go)
            {
                MonoBehaviour[] components = go.GetComponentsInChildren<MonoBehaviour>(true);
                foreach (MonoBehaviour mb in components)
                {
                    await LoadAllAssetReferences(mb, owner, cancellationToken);
                }
            }
        }
    }
}
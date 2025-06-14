using System;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.IMGUIUtility.Runtime.ElementStack.IconStack.Attributes;
using VladislavTsurikov.MegaWorld.Runtime.Core.SelectionDatas.Group.DefaultComponentsSystem;
using VladislavTsurikov.ReflectionUtility;
using VladislavTsurikov.UnityUtility.Runtime;
using Object = UnityEngine.Object;

namespace VladislavTsurikov.MegaWorld.Runtime.Core.SelectionDatas.Group.Prototypes.PrototypeGameObject
{
    [Serializable]
    [Name("Unity/GameObject")]
    [DropObjects(new[]{typeof(GameObject)})]
    [MissingIconsWarning("Drag & Drop Prefabs Here")]
    [AddDefaultGroupComponents(new []{typeof(ContainerForGameObjects)})]
    public class PrototypeGameObject : PlacedObjectPrototype
    {
        public override bool IsSamePrototypeObject(Object obj)
        {
            GameObject go = (GameObject)obj;

            return GameObjectUtility.IsSameGameObject(go, Prefab);
        }
    }
}
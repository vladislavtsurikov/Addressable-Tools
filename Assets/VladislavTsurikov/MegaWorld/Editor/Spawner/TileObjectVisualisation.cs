#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VladislavTsurikov.MegaWorld.Editor.Common.Settings.OverlapCheckSettings;
using VladislavTsurikov.MegaWorld.Runtime.Common.Stamper;

namespace VladislavTsurikov.MegaWorld.Editor.Spawner
{
    public static class TileObjectVisualisation
    {
        [DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.Selected)]
        private static void DrawGizmoForArea(Runtime.Spawner.Spawner stamper, GizmoType gizmoType)
        {
            bool isFaded = (int)gizmoType == (int)GizmoType.NonSelected || (int)gizmoType == (int)GizmoType.NotInSelectionHierarchy || (int)gizmoType == (int)GizmoType.NonSelected + (int)GizmoType.NotInSelectionHierarchy;
            
            if(stamper.Area.DrawHandleIfNotSelected == false)
            {
                if(isFaded)
                {
                    return;
                }
            }
            
            Bounds bounds = new Bounds(Camera.current.transform.position, new Vector3(300f, 300f, 300f));
            
            OverlapVisualisation.Draw(bounds, stamper.Data);
            
            float opacity = isFaded ? 0.5f : 1.0f;
            
            AreaVisualisation.DrawBox(stamper.Area, opacity);
        }
    }
}
#endif
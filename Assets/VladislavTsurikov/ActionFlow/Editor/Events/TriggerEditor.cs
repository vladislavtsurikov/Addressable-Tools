#if UNITY_EDITOR
using Assemblies.VladislavTsurikov.IMGUIUtility.Editor.ElementStack.SingleElementStackEditor;
using OdinSerializer;
using UnityEditor;
using UnityEngine;
using VladislavTsurikov.ActionFlow.Runtime.Events;
using VladislavTsurikov.IMGUIUtility.Editor.ElementStack;
using VladislavTsurikov.IMGUIUtility.Editor.ElementStack.ReorderableList;
using Action = VladislavTsurikov.ActionFlow.Runtime.Actions.Action;
using Actions_Action = VladislavTsurikov.ActionFlow.Runtime.Actions.Action;
using Event = VladislavTsurikov.ActionFlow.Runtime.Events.Event;
using Events_Event = VladislavTsurikov.ActionFlow.Runtime.Events.Event;
using Runtime_Actions_Action = VladislavTsurikov.ActionFlow.Runtime.Actions.Action;
using Runtime_Events_Event = VladislavTsurikov.ActionFlow.Runtime.Events.Event;

namespace VladislavTsurikov.ActionFlow.Editor.Events
{
    [CustomEditor(typeof(Trigger))]
    public class TriggerEditor : UnityEditor.Editor
    {
        private Trigger Trigger => (Trigger)target;
        
        private ReorderableListStackEditor<Runtime_Actions_Action, ReorderableListComponentEditor> _actionsCollectionEditor;
        private SingleElementStackEditor<Runtime_Events_Event, IMGUIElementEditor> _singleElementStackEditor;

        private void OnEnable()
        {
            _actionsCollectionEditor = new ReorderableListStackEditor<Runtime_Actions_Action, ReorderableListComponentEditor>(
                new GUIContent("Actions"), Trigger.ActionCollection, true);
            
            _singleElementStackEditor = new SingleElementStackEditor<Runtime_Events_Event, IMGUIElementEditor>(Trigger.SingleElementStack);
        }

        public override void OnInspectorGUI()
        {
            _singleElementStackEditor.OnGUI();
            
            GUILayout.Space(3);

            _actionsCollectionEditor.OnGUI();
        }
    }
}
#endif
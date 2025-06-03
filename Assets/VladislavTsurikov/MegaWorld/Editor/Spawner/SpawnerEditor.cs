#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VladislavTsurikov.MegaWorld.Editor.Core.MonoBehaviour;
using VladislavTsurikov.MegaWorld.Runtime.Common.Stamper.AutoRespawn;
using VladislavTsurikov.MegaWorld.Runtime.Core.SelectionDatas.Group;
using VladislavTsurikov.MegaWorld.Runtime.Core.SelectionDatas.Group.Prototypes;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.MegaWorld.Editor.Spawner
{
	[Name("Spawner")]
    [CustomEditor(typeof(Runtime.Spawner.Spawner))]
	public sealed class SpawnerEditor : MonoBehaviourToolEditor
    {
		private Runtime.Spawner.Spawner _stamperTool;
		
        protected override void OnInit()
        {
            _stamperTool = (Runtime.Spawner.Spawner)target;

            _stamperTool.Area.SetAreaBounds(_stamperTool);
        }

        public override void OnChangeGUIGroup(Group group)
		{
			if (!_stamperTool.StamperControllerSettings.AutoRespawn)
			{
				return;
			}
			
			_stamperTool.AutoRespawnController.StartAutoRespawn(_stamperTool.StamperControllerSettings.DelayAutoRespawn, new RespawnGroup(_stamperTool));
		}

		public override void OnChangeGUIPrototype(Prototype proto)
		{
			if (!_stamperTool.StamperControllerSettings.AutoRespawn)
			{
				return;
			}

			_stamperTool.AutoRespawnController.StartAutoRespawn(_stamperTool.StamperControllerSettings.DelayAutoRespawn, new RespawnGroup(_stamperTool));
		}

		[MenuItem("GameObject/MegaWorld/Spawner", false, 14)]
    	public static void AddStamper(MenuCommand menuCommand)
    	{
    		GameObject stamper = new GameObject("Spawner")
            {
	            transform =
	            {
		            localScale = new Vector3(500, 500, 500)
	            }
            };
            stamper.AddComponent<Runtime.Spawner.Spawner>();
            UnityEditor.Undo.RegisterCreatedObjectUndo(stamper, "Created " + stamper.name);
    		Selection.activeObject = stamper;
    	}
    }
}
#endif
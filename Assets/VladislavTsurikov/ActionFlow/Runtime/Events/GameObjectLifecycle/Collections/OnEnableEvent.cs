using System;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.SceneUtility.Runtime;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.GameObjectLifecycle
{
    [Name("Lifecycle/On Enable")]
    public class OnEnableEvent : LifecycleEvent
    {
        protected internal override void OnEnable()
        {
            Trigger.Run();
        }
    }
}
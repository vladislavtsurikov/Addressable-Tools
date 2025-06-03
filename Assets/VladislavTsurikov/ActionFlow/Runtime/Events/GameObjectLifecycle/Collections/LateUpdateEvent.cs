using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.GameObjectLifecycle
{
    [Name("Lifecycle/Late Update")]
    public class LateUpdateEvent : LifecycleEvent
    {
        protected internal override void LateUpdate()
        {
            Trigger.Run();
        }
    }
}
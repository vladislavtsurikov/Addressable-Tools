using UnityEngine.EventSystems;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.UnityUI
{
    [Name("Unity UI/On Deselect")]
    public class OnDeselectPointerEvent : UISelectEvent
    {
        protected internal override void OnDeselect(BaseEventData eventData)
        {
            Trigger.Run();
        }
    }
}
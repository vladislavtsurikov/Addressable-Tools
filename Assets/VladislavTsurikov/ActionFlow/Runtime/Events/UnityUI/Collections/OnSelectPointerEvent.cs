using UnityEngine.EventSystems;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.UnityUI
{
    [Name("Unity UI/On Select")]
    public class OnSelectPointerEvent : UISelectEvent
    {
        protected internal override void OnSelect(BaseEventData eventData)
        {
            Trigger.Run();
        }
    }
}
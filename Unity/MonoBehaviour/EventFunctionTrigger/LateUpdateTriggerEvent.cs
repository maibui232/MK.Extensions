namespace MK.Extensions
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class LateUpdateTriggerEvent : BaseTriggerEvent
    {
        private void LateUpdate()
        {
            this.OnTriggerAction();
        }
    }
}
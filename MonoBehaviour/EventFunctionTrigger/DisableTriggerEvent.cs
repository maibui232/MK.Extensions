namespace MK.Extensions
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class DisableTriggerEvent : BaseTriggerEvent
    {
        private void OnDisable()
        {
            this.OnTriggerAction();
        }
    }
}
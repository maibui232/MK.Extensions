namespace MK.Extensions
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class FixUpdateTriggerEvent : BaseTriggerEvent
    {
        private void FixedUpdate()
        {
            this.OnTriggerAction();
        }
    }
}
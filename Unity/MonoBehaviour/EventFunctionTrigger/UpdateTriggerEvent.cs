namespace MK.Extensions
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class UpdateTriggerEvent : BaseTriggerEvent
    {
        private void Update()
        {
            this.OnTriggerAction();
        }
    }
}
namespace MK.Extensions
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class EnableTriggerEvent : BaseTriggerEvent
    {
        private void OnEnable()
        {
            this.OnTriggerAction();
        }
    }
}
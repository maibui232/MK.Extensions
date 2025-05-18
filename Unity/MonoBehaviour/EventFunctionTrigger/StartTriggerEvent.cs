namespace MK.Extensions
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class StartTriggerEvent : BaseTriggerEvent
    {
        private void Start()
        {
            this.OnTriggerAction();
        }
    }
}
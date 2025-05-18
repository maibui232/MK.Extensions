namespace MK.Extensions
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class AwakeTriggerEvent : BaseTriggerEvent
    {
        private void Awake()
        {
            this.OnTriggerAction();
        }
    }
}
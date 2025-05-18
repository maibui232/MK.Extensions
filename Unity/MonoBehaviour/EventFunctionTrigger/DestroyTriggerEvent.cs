namespace MK.Extensions
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public class DestroyTriggerEvent : BaseTriggerEvent
    {
        protected override void OnDestroy()
        {
            this.OnTriggerAction();
            base.OnDestroy();
        }
    }
}
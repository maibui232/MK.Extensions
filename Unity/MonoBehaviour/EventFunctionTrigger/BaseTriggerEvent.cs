namespace MK.Extensions
{
    using System;
    using System.Collections;
    using UnityEngine;

    public abstract class BaseTriggerEvent : MonoBehaviour
    {
        private event Action TriggerAction;

        public void Subscribe(Action callback)
        {
            this.TriggerAction += callback;
        }

        public void Unsubscribe(Action callback)
        {
            this.TriggerAction -= callback;
        }

        protected virtual void OnDestroy()
        {
            this.StopAllCoroutines();
        }

        protected void OnTriggerAction()
        {
            this.StartCoroutine(this.TriggerAsync());
        }

        private IEnumerator TriggerAsync()
        {
            yield return new WaitUntil(() => this.TriggerAction != null);
            this.TriggerAction?.Invoke();
        }
    }
}
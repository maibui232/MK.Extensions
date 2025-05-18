namespace MK.Extensions
{
    using UnityEngine;

    public static class MonoTriggerEventExtensions
    {
        public static T GetOrAddTriggerEvent<T>(this GameObject gameObject) where T : BaseTriggerEvent
        {
            if (gameObject.TryGetComponent<T>(out var comp))
            {
                return comp;
            }

            var instanceComp = gameObject.AddComponent<T>();

            return instanceComp;
        }
    }
}
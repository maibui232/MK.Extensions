namespace MK.Extensions
{
    using UnityEngine;

    public static class UnityExtensions
    {
        public static void DontDestroyOnLoad(this Object gameObject)
        {
            Object.DontDestroyOnLoad(gameObject);
        }
    }
}
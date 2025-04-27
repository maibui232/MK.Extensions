namespace MK.Extensions
{
    using System;
    using System.Reflection;

    public static class AttributeExtensions
    {
        public static string GetKey(this Type type)
        {
            var key = (KeyAttribute)type.GetCustomAttribute(typeof(KeyAttribute), false);
            return key is not null ? key.Key : type.Name;
        }
    }
}
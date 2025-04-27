namespace MK.Extensions
{
    using System;

    public class KeyAttribute : Attribute
    {
        public KeyAttribute(string key)
        {
            this.Key = key;
        }

        internal string Key { get; }
    }
}
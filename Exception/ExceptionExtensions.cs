namespace MK.Extensions
{
    using System;
    using MK.Log;

    public static class ExceptionExtensions
    {
        public static void ThrowIfNotAssignable(this ILogger logger, Type type, Type baseType)
        {
            logger.Fatal(new Exception($"{type.FullName} is not assignable to {baseType.FullName}"));
        }
    }
}
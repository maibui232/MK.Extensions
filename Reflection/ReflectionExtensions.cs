namespace MK.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class ReflectionExtensions
    {
        public static Type GetSingleDerived<T>()
        {
            return typeof(T).GetSingleDerived();
        }

        public static Type GetSingleDerived(this Type baseType)
        {
            var derivedTypes = baseType.GetDerivedTypes();
            switch (derivedTypes.Length)
            {
                case 0:  throw new ArrayTypeMismatchException($"{baseType.FullName} must be one or more derived types.");
                case 1:  return derivedTypes.First();
                default: throw new ArrayTypeMismatchException($"There must be one or more derived types. Type: {baseType.FullName}.");
            }
        }

        public static Type[] GetDerivedTypes<T>()
        {
            var baseType = typeof(T);

            return baseType.GetDerivedTypes();
        }

        public static Type[] GetDerivedTypes(this Type baseType)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
               .SelectMany(asm => asm.GetTypes())
               .Where(type => !type.IsAbstract && type.IsSubclassOf(baseType))
               .ToArray();
        }

        public static ConstructorInfo GetSingleConstructor(this Type type)
        {
            var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            return ctors.Length switch
                   {
                       1   => ctors[0],
                       > 1 => throw new AmbiguousMatchException($"{type.FullName} must have exactly one public constructor."),
                       _   => throw new AmbiguousMatchException($"{type.FullName} must have one public constructor.")
                   };
        }
    }
}
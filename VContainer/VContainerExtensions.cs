namespace MK.Extensions
{
    using System;
    using VContainer;
    using VContainer.Internal;

    public static class VContainerExtensions
    {
        public static T InstantiateConcrete<T>(this IObjectResolver resolver) where T : class
        {
            var type = typeof(T);

            return resolver.InstantiateConcrete(type) as T;
        }

        public static object InstantiateConcrete(this IObjectResolver resolver, Type type)
        {
            var injector = InjectorCache.GetOrBuild(type);

            return injector.CreateInstance(resolver, null);
        }

        public static void NonLazy<T>(this IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(resolver => resolver.Resolve<T>());
        }
    }
}
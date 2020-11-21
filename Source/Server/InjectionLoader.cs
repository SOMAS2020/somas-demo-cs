using System;
using System.Collections.Generic;
using System.Linq;

// ================================================================================
// Some fancy stuff I wrote that you don't need to worry about
// It just means that the server can automatically create the clients
// ================================================================================

namespace Server
{
    /// <summary>
    /// Prevents the type from being loaded by an InjectionLoader
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class NoInjectAttribute : Attribute { }

    /// <summary>
    /// Loads and instantiates instances of the injectable types.
    /// </summary>
    /// <typeparam name="T">The base type for the instances that will be injected.</typeparam>
    public class InjectionLoader<T>
    {
        private Type[] _injectableTypes;

        /// <summary>
        /// Retrieves all of the injectable types.
        /// </summary>
        /// <param name="forceReload">Forces a reload of the types instead of using the cache.</param>
        /// <returns>The injectable types.</returns>
        public Type[] GetInjectableTypes(bool forceReload = false)
        {
            if (_injectableTypes == null || forceReload)
            {
                _injectableTypes = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(type => typeof(T).IsAssignableFrom(type))
                    .Where(type => !type.IsAbstract)
                    .Where(type => !type.IsDefined(typeof(NoInjectAttribute), false))
                    .ToArray();
            }

            return _injectableTypes;
        }

        /// <summary>
        /// Creates instances for all of the injectable types available.
        /// </summary>
        /// <param name="forceReload">Forces a reload of the types instead of using the cache.</param>
        /// <returns>The injectable instances.</returns>
        public IEnumerable<T> GetInjectedInstances(bool forceReload = false)
        {
            IEnumerable<Type> injectableTypes = GetInjectableTypes(forceReload);
            return GetInjectedInstances(injectableTypes);
        }

        /// <summary>
        /// Creates instances from a custom sequence of injectable types.
        /// </summary>
        /// <param name="injectableTypes">The types to create instances for.</param>
        /// <returns>The injectable instances.</returns>
        public IEnumerable<T> GetInjectedInstances(IEnumerable<Type> injectableTypes)
        {
            foreach (Type type in injectableTypes)
            {
                T instance = default;
                bool success = false;

                try
                {
                    instance = (T)Activator.CreateInstance(type);
                    success = true;
                }
                catch (MissingMethodException)
                {
                    Console.WriteLine($"Could not load {typeof(T)} {type} as it is missing a public parameterless constructor.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                if (success && instance != null)
                {
                    yield return instance;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Chapter.ServiceLocator
{
    public static class ServiceLocator
    {
        private static readonly IDictionary<Type, object> _services = new Dictionary<Type, Object>();

        public static void RegisterService<T>(T service)
        {
            if (!_services.ContainsKey(typeof(T)))
            {
                _services[typeof(T)] = service;
            }
            else
            {
                throw new ApplicationException("Service already registered");
            }
        }

        public static T GetService<T>()
        {
            try
            {
                return (T) _services[typeof(T)];
            }
            catch
            {
                throw new ApplicationException("Requested service not found.");
            }
        }
    }
}
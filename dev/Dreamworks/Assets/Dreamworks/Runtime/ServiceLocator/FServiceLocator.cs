/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.ServiceLocator
{
    /// <summary>
    /// Provide a global point of access to a service without coupling users to the concrete class that implements it.
    /// </summary>
    /// <see cref="http://gameprogrammingpatterns.com/service-locator.html"/>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/14/2019</CreationDate>
    public static class FServiceLocator
    {
        #region Field
        private readonly static IDictionary<Type, object> registeredServices = new Dictionary<Type, object>();
        #endregion

        #region Property
        public static Type CLASS_TYPE { get; } = typeof(FServiceLocator);
        #endregion

        #region IServiceLocator Implementation
        /// <summary>
        /// Register a service with given instance as singleton in ServiceLocator.
        /// </summary>
        /// <typeparam name="TService">Service type</typeparam>
        /// <param name="service">Service instance</param>
        public static void Register<TService>(object service) where TService : class, IService
        {
            if (service == null)
            {
                FLog.LogError("Service instance can't be null.", null, CLASS_TYPE.Name);

                return;
            }

            if ((service as TService) == null)
            {
                FLog.LogError($"`{service.GetType().Name}` Service instance doesn't implemented `{typeof(TService).Name}` interface.", null, CLASS_TYPE.Name);

                return;
            }

            Type serviceType = typeof(TService);

            if (registeredServices.ContainsKey(serviceType) == true)
            {
                FLog.LogWarning($"`{service.GetType().Name}` service is already registered.", null, CLASS_TYPE.Name);

                return;
            }

            registeredServices.Add(serviceType, service);

            FLog.Log($"`{service.GetType().Name}` service has been registered.", null, CLASS_TYPE.Name);
        }

        /// <summary>
        /// return instance of given service if it has been registered before.
        /// </summary>
        /// <typeparam name="TService">ServiceType</typeparam>
        /// <returns>Service instance of given type</returns>
        public static TService Resolve<TService>() where TService : class, IService
        {
            Type serviceType = typeof(TService);

            return registeredServices[serviceType] as TService;
        }

        public static void Remove<T>()
        {
            Remove(typeof(T));
        }

        public static void Remove(Type serviceType)
        {
            registeredServices.Remove(serviceType);
        }
        #endregion
    }
}
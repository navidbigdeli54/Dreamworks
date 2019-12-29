/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0059

using System;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.EventManager
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>December/18/2019</CreationDate>
    public static class FEventManager
    {
        #region Fields
        private static readonly IDictionary<string, DEventSubscriber> eventTosubscribers = new Dictionary<string, DEventSubscriber>(100, StringComparer.OrdinalIgnoreCase);
        #endregion

        #region Properties
        public static IReadOnlyDictionary<string, DEventSubscriber> Events => eventTosubscribers as IReadOnlyDictionary<string, DEventSubscriber>;
        #endregion

        #region Methods
        public static void Publish(string name) => Publish(name, EventArgs.Empty);

        public static void Publish(string name, EventArgs args)
        {
            FAssert.IsFalse(string.IsNullOrEmpty(name));

            if (eventTosubscribers.TryGetValue(name, out DEventSubscriber subscribers))
            {
                subscribers?.Invoke(args);
            }
        }

        public static void Subscribe(string name, DEventSubscriber subscriber)
        {
            FAssert.IsFalse(string.IsNullOrEmpty(name));

            if (eventTosubscribers.ContainsKey(name))
            {
                eventTosubscribers[name] += subscriber;
            }
            else
            {
                eventTosubscribers.Add(name, subscriber);
            }
        }

        public static void Unsubscribe(string name, DEventSubscriber subscriber)
        {
            FAssert.IsFalse(string.IsNullOrWhiteSpace(name));

            if (eventTosubscribers.ContainsKey(name))
            {
                eventTosubscribers[name] -= subscriber;
            }
        }
        #endregion

        #region Nested Type
        public delegate void DEventSubscriber(EventArgs eventData);
        #endregion
    }
}
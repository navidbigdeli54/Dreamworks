/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0059

using System;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.EventManager
{
    public static class FEventManager
    {
        #region Fields
        private static readonly IDictionary<FStringId, DEventSubscriber> eventTosubscribers = new Dictionary<FStringId, DEventSubscriber>(100);
        #endregion

        #region Properties
        public static IReadOnlyDictionary<FStringId, DEventSubscriber> Events => eventTosubscribers as IReadOnlyDictionary<FStringId, DEventSubscriber>;
        #endregion

        #region Methods
        public static void Publish(FStringId name) => Publish(name, EventArgs.Empty);

        public static void Publish(FStringId name, EventArgs args)
        {
            if (eventTosubscribers.TryGetValue(name, out DEventSubscriber subscribers))
            {
                subscribers?.Invoke(args);
            }
        }

        public static void Subscribe(FStringId name, DEventSubscriber subscriber)
        {
            if (eventTosubscribers.ContainsKey(name))
            {
                eventTosubscribers[name] += subscriber;
            }
            else
            {
                eventTosubscribers.Add(name, subscriber);
            }
        }

        public static void Unsubscribe(FStringId name, DEventSubscriber subscriber)
        {
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
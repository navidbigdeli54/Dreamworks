/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.EventManagement
{
    /// <summary>
    /// It is an Publisher/Subscriber pattern.
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>April/28/2018</CreationDate>
    public interface IEventManagement : IService
    {
        #region Method
        /// <summary>
        /// Subscribe a method for desire event.
        /// </summary>
        /// <param name="name">Desire event name to subscribe.</param>
        /// <param name="subscriber">Desire method to subscribe to the given event name.</param>
        void Subscribe(string name, DEventSubscriber subscriber);

        /// <summary>
        /// Unsubscribe a method from desire event.
        /// </summary>
        /// <param name="name">Desire event to unsubscribe from.</param>
        /// <param name="subscriber">Desire method to unsubscribe from the given event name.</param>
        void Unsubscribe(string name, DEventSubscriber subscriber);

        /// <summary>
        /// Rise desire event and pass to all subscriber given data.
        /// </summary>
        /// <param name="name">Desire event's name to rise.</param>
        /// <param name="data">Desire data to pass to the subscribers.</param>
        void Publish(string name, EventArgs args);

        /// <summary>
        /// Rise desire event without any data.
        /// </summary>
        /// <param name="name">Desire event's name to rise.</param>
        void Publish(string name);

        /// <summary>
        /// Add a new event into EventManagement
        /// </summary>
        /// <param name="name">name of the event</param>
        void AddEvent(string name);

        /// <summary>
        /// Remove an event from EventMangement
        /// </summary>
        /// <param name="name">name of the event</param>
        void RemoveEvent(string name);
        #endregion
    }
}
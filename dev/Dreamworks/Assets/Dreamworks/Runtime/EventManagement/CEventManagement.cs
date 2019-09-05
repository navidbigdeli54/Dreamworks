/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.ServiceLocator;

namespace DreamMachineGameStudio.Dreamworks.EventManagement
{
    /// <summary>
    /// Implementation of IEventSystem.
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>April/28/2018</CreationDate>
    public sealed class CEventManagement : CService, IEventManagement
    {
        #region Field
        private readonly Dictionary<string, DEventSubscriber> events = new Dictionary<string, DEventSubscriber>(100);
        #endregion

        #region Property
        public static new Type CLASS_TYPE { get; private set; } = typeof(CEventManagement);
        #endregion

        #region CService Methods
        protected override Task InitializeComponentAsync()
        {
            name = nameof(CEventManagement);

            MakePersistent();

            InitializeDefualtEvents();

            return Task.CompletedTask;
        }

        protected override async Task UninitializeCompoonentAsync()
        {
            await base.UninitializeCompoonentAsync();

            FServiceLocator.Remove<IEventManagement>();
        }

        private void InitializeDefualtEvents()
        {
            events.Add(FDefaultEventNameHelper.ON_BEGIN_PLAY, null);
            events.Add(FDefaultEventNameHelper.ON_GAME_MODE_LOADED, null);
            events.Add(FDefaultEventNameHelper.ON_INITIALIZATION, null);
            events.Add(FDefaultEventNameHelper.ON_ACTIVE_SCENE_CHANGED, null);
            events.Add(FDefaultEventNameHelper.ON_SCENE_LOADED, null);
            events.Add(FDefaultEventNameHelper.ON_SCENE_UNLOADED, null);
        }
        #endregion

        #region IEventSystem Implementation
        void IEventManagement.Publish(string name)
        {
            ((IEventManagement)this).Publish(name, null);
        }

        void IEventManagement.Publish(string name, EventArgs args)
        {
            if (string.IsNullOrEmpty(name))
            {
                FLog.LogError($"Name parameter should not be null.", null, CLASS_TYPE.Name);

                return;
            }

            if (events.ContainsKey(name) == false)
            {
                FLog.LogError($"`{name}` event dose not exist.", null, CLASS_TYPE.Name);

                return;
            }

            events[name]?.Invoke(args);
        }

        void IEventManagement.Subscribe(string name, DEventSubscriber subscriber)
        {
            if (string.IsNullOrEmpty(name))
            {
                FLog.LogError("Name parameter should not be null.", null, CLASS_TYPE.Name);

                return;
            }

            if (subscriber == null)
            {
                FLog.LogError("Subscriber should not be null.", null, CLASS_TYPE.Name);

                return;
            }

            if (events.ContainsKey(name) == false)
            {
                FLog.LogError($"`{name}` event dose not exist.", null, CLASS_TYPE.Name);

                return;
            }

            events[name] += subscriber;
        }

        void IEventManagement.Unsubscribe(string name, DEventSubscriber subscriber)
        {
            if (string.IsNullOrEmpty(name))
            {
                FLog.LogError("Name parameter should not be null.", null, CLASS_TYPE.Name);

                return;
            }

            if (subscriber == null)
            {
                FLog.LogError("Subscriber should not be null.", null, CLASS_TYPE.Name);

                return;
            }

            events[name] -= subscriber;
        }

        void IEventManagement.AddEvent(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                FLog.LogError("Name parameter should not be null.", null, CLASS_TYPE.Name);

                return;
            }

            if (events.ContainsKey(name))
            {
                FLog.LogError($"`{name}` event has already exist.", null, CLASS_TYPE.Name);
            }

            events.Add(name, null);
        }

        void IEventManagement.RemoveEvent(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                FLog.LogError("Name parameter should not be null.", null, CLASS_TYPE.Name);

                return;
            }

            if (events.ContainsKey(name) == false)
            {
                FLog.LogError($"`{name}` event doesn't exist.", null, CLASS_TYPE.Name);
            }

            events.Remove(name);
        }
        #endregion
    }

}
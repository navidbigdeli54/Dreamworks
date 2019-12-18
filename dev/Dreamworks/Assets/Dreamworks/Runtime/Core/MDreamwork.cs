/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0051

using System;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.Persistent;
using DreamMachineGameStudio.Dreamworks.EventManager;
using DreamMachineGameStudio.Dreamworks.ServiceLocator;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/14/2019</CreationDate>
    public sealed class MDreamwork : MonoBehaviour
    {
        #region Field
        private readonly List<IInitializable> registeredObjects = new List<IInitializable>();

        private readonly List<IInitializable> pendingRegiserationRequests = new List<IInitializable>();

        private readonly List<ITickable> registeredTicks = new List<ITickable>();

        private readonly List<ITickable> registeredLateTicks = new List<ITickable>();

        private readonly List<ITickable> registeredFixedTick = new List<ITickable>();

        private readonly HashSet<IInitializable> initializablesHolder = new HashSet<IInitializable>();

        private readonly HashSet<ITickable> ticksHolder = new HashSet<ITickable>();

        private readonly HashSet<ITickable> lateTicksHolder = new HashSet<ITickable>();

        private readonly HashSet<ITickable> fixedTicksHolder = new HashSet<ITickable>();
        #endregion

        #region Property
        public Type CLASS_TYPE => typeof(MDreamwork);

        public static MDreamwork Instance { get; private set; }

        public bool HasInitialized { get; set; }

        public bool HasBeganPlay { get; set; }
        #endregion

        #region MonoBehaviour Methods
        private void Awake()
        {
            if (Instance == null)
            {
                name = nameof(MDreamwork);

                CPersistent.MakePersistent(gameObject);

                Instance = this;
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        private void Update()
        {
            int count = registeredTicks.Count;

            for (int i = 0; i < count; i++)
            {
                ITickable tickable = registeredTicks[i];

                if (tickable == null) continue;

                if (HasInitialized == false) continue;

                if (tickable is IInitializable initializable && initializable.HasInitialized == false) continue;

                if (tickable.CanEverTick == false) continue;

                if (HasBeganPlay == false && tickable.CanTickBeforePlay == false) continue;

                try
                {
                    tickable.Tick(Time.deltaTime);
                }
                catch (Exception exception)
                {
                    FLog.Error(CLASS_TYPE.Name, exception.Message);
                }
            }
        }

        private void LateUpdate()
        {
            int count = registeredLateTicks.Count;

            for (int i = 0; i < count; i++)
            {
                ITickable tickable = registeredLateTicks[i];

                if (tickable == null) continue;

                if (this.HasInitialized == false) continue;

                if (tickable is IInitializable initializable && initializable.HasInitialized == false) continue;

                if (tickable.CanEverLateTick == false) continue;

                if (HasBeganPlay == false && tickable.CanLateTickBeforePlay == false) continue;

                try
                {
                    tickable.LateTick(Time.deltaTime);
                }
                catch (Exception exception)
                {
                    FLog.Error(CLASS_TYPE.Name, exception.Message);
                }
            }
        }

        private void FixedUpdate()
        {
            int count = registeredFixedTick.Count;

            for (int i = 0; i < count; i++)
            {
                ITickable tickable = registeredFixedTick[i];

                if (tickable == null) continue;

                if (this.HasInitialized == false) continue;

                if (tickable is IInitializable initializable && initializable.HasInitialized == false) continue;

                if (tickable.CanEverFixedTick == false) continue;

                if (HasBeganPlay == false && tickable.CanFixedTickBeforePlay == false) continue;

                try
                {
                    tickable.FixedTick(Time.deltaTime);
                }
                catch (Exception exception)
                {
                    FLog.Error(CLASS_TYPE.Name, exception.Message);
                }
            }
        }
        #endregion

        #region Method
        public async void StartUp()
        {
            await InitializeServicesAsync();

            FEventManager.Subscribe(FDefaultEventNameHelper.ON_GAME_MODE_LOADED, OnGameModeLoaded);

            FEventManager.Subscribe(FDefaultEventNameHelper.ON_SCENE_UNLOADED, OnSceneUnloaded);
        }

        public async Task RegisterAsycn(IInitializable initializable)
        {
            if (initializablesHolder.Contains(initializable))
            {
                FLog.Warning(CLASS_TYPE.Name, $"{initializable.Name} has already registered");

                return;
            }

            if (HasInitialized == false)
            {
                if (initializable is IService && (initializable is IGameService) == false)
                {
                    registeredObjects.Add(initializable);
                }
                else
                {
                    pendingRegiserationRequests.Add(initializable);
                }
            }
            else
            {
                if (initializable is IService && (initializable is IGameService) == false)
                {
                    FLog.Error(CLASS_TYPE.Name, $"{initializable.Name} is a service and should not be registered during game play, use GameStartup to register them. Registration aborted.");

                    return;
                }

                await initializable.PreInitializeAsync();

                await initializable.InitializeAsync();

                await initializable.BeginPlayAsync();
            }

            initializablesHolder.Add(initializable);
        }

        public async Task UnregisterAsync(IInitializable initializable)
        {
            if (initializablesHolder.Contains(initializable) == false)
            {
                FLog.Warning(CLASS_TYPE.Name, $"{initializable.Name} has not registered but wants to unregister itself.");

                return;
            }

            await initializable.UninitializeAsync();

            registeredObjects.Remove(initializable);

            initializablesHolder.Remove(initializable);

            if (initializable is ITickable tickable)
            {
                if (ticksHolder.Contains(tickable))
                    UnregisterTick(tickable);

                if (lateTicksHolder.Contains(tickable))
                    UnregisterLateTick(tickable);

                if (fixedTicksHolder.Contains(tickable))
                    UnregisterFixedTick(tickable);
            }
        }

        public void RegisterTick(ITickable tickable)
        {
            if (ticksHolder.Contains(tickable))
            {
                FLog.Warning(CLASS_TYPE.Name, $"{tickable.Name} already registered for tick.");

                return;
            }

            registeredTicks.Add(tickable);

            ticksHolder.Add(tickable);
        }

        public void UnregisterTick(ITickable tickable)
        {
            if (ticksHolder.Contains(tickable) == false)
            {
                FLog.Warning(CLASS_TYPE.Name, $"{tickable.Name} has not registered for tick but wants to unregister.");

                return;
            }

            registeredTicks.Remove(tickable);

            ticksHolder.Remove(tickable);
        }

        public void RegisterLateTick(ITickable tickable)
        {
            if (lateTicksHolder.Contains(tickable))
            {
                FLog.Warning(CLASS_TYPE.Name, $"{tickable.Name} already registered for late tick.");

                return;
            }

            registeredLateTicks.Add(tickable);

            lateTicksHolder.Add(tickable);
        }

        public void UnregisterLateTick(ITickable tickable)
        {
            if (lateTicksHolder.Contains(tickable) == false)
            {
                FLog.Warning(CLASS_TYPE.Name, $"{tickable.Name} has not registered for late tick but wants to unregister.");

                return;
            }

            registeredLateTicks.Remove(tickable);

            lateTicksHolder.Remove(tickable);
        }

        public void RegisterFixedTick(ITickable tickable)
        {
            if (fixedTicksHolder.Contains(tickable))
            {
                FLog.Warning(CLASS_TYPE.Name, $"{tickable.Name} already registered for fixed tick.");

                return;
            }

            registeredFixedTick.Add(tickable);

            fixedTicksHolder.Add(tickable);
        }

        public void UnregisterFixedTick(ITickable tickable)
        {
            if (fixedTicksHolder.Contains(tickable) == false)
            {
                FLog.Warning(CLASS_TYPE.Name, $"{tickable.Name} has not registered for fixed tick but wants to unregister.");

                return;
            }

            registeredFixedTick.Remove(tickable);

            fixedTicksHolder.Remove(tickable);
        }
        #endregion

        #region Helpers
        private async Task InitializeServicesAsync()
        {
            /*
             * In registration process, if framework was not initialized yet, we only register IService instances and put all other instances to pending list.
             * So we safely assume that at this moment, only IService instances are in _registeredObjects list.
             */

            await PreinitializeAsync(registeredObjects);

            await InitializeAsync(registeredObjects);

            await BeginPlayAsync(registeredObjects);
        }

        private async Task PreinitializeAsync(List<IInitializable> list)
        {
            int count = list.Count;

            for (int i = 0; i < count; i++)
            {
                try
                {
                    IInitializable initializable = list[i];

                    if (initializable.HasInitialized) continue;

                    await initializable.PreInitializeAsync();
                }
                catch (Exception exception)
                {
                    FLog.Error(CLASS_TYPE.Name, exception);
                }
            }
        }

        private async Task InitializeAsync(List<IInitializable> list)
        {
            int count = list.Count;

            for (int i = 0; i < count; i++)
            {
                try
                {
                    IInitializable initializable = list[i];

                    if (initializable.HasInitialized) continue;

                    await initializable.InitializeAsync();
                }
                catch (Exception exception)
                {
                    FLog.Error(CLASS_TYPE.Name, exception);
                }
            }
        }

        private async Task BeginPlayAsync(List<IInitializable> list)
        {
            int count = list.Count;

            for (int i = 0; i < count; i++)
            {
                try
                {
                    IInitializable initializable = list[i];

                    if (initializable.HasBeganPlay) continue;

                    await initializable.BeginPlayAsync();
                }
                catch (Exception exception)
                {
                    FLog.Error(CLASS_TYPE.Name, exception);
                }
            }
        }

        private async void OnGameModeLoaded(object arg)
        {
            HasInitialized = true;

            await PreinitializeAsync(pendingRegiserationRequests);

            await InitializeAsync(pendingRegiserationRequests);

            await BeginPlayAsync(pendingRegiserationRequests);

            HasBeganPlay = true;

            registeredObjects.AddRange(pendingRegiserationRequests);
        }

        private void OnSceneUnloaded(object arg)
        {
            HasBeganPlay = false;
        }
        #endregion
    }
}
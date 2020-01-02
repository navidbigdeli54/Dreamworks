/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using System.Threading.Tasks;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.Utility;
using DreamMachineGameStudio.Dreamworks.EventManager;
using DreamMachineGameStudio.Dreamworks.SceneManagement;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/31/2018</CreationDate>
    public abstract class CGameManagement : CComponent, IGameManagement
    {
        #region Property
        public new static Type CLASS_TYPE => typeof(CGameManagement);

        protected IGameMode CurrentGameMode { get; private set; }
        #endregion

        #region Method
        protected async override Task InitializeComponentAsync()
        {
            await base.InitializeComponentAsync();

            MakePersistent();

            FEventManager.Subscribe(FDefaultEventNameHelper.ON_SCENE_LOADED, OnSceneLoaded);
            FEventManager.Subscribe(FDefaultEventNameHelper.ON_SCENE_UNLOADED, OnSceneUnloaded);
        }

        protected override void TickComponent(float deltaTime)
        {
            base.TickComponent(deltaTime);

            if (CurrentGameMode == null) return;

            if (CurrentGameMode.HasInitialized == false) return;

            if (CurrentGameMode.HasInitialized && CurrentGameMode.HasBeganPlay == false && CurrentGameMode.CanTickBeforePlay == false) return;

            CurrentGameMode.Tick(deltaTime);
        }

        protected override void LateTickComponent(float deltaTime)
        {
            base.LateTickComponent(deltaTime);

            if (CurrentGameMode == null) return;

            if (CurrentGameMode.HasInitialized == false) return;

            if (CurrentGameMode.HasInitialized && CurrentGameMode.HasBeganPlay == false && CurrentGameMode.CanLateTickBeforePlay == false) return;

            CurrentGameMode.LateTick(deltaTime);
        }

        protected override void FixedTickComponent(float deltaTime)
        {
            base.FixedTickComponent(deltaTime);

            if (CurrentGameMode == null) return;

            if (CurrentGameMode.HasInitialized == false) return;

            if (CurrentGameMode.HasInitialized && CurrentGameMode.HasBeganPlay == false && CurrentGameMode.CanFixedTickBeforePlay == false) return;

            CurrentGameMode.FixedTick(deltaTime);
        }
        #endregion

        #region Helpers
        private async void OnSceneLoaded(EventArgs arg)
        {
            FSceneLoadedEventArg eventArg = (FSceneLoadedEventArg)arg;

            CLevelConfig metadata = FindObjectOfType<CLevelConfig>();

            if (metadata == null)
            {
                FLog.Warning(CLASS_TYPE.Name, $"Cannot find scene metadata `S{eventArg.Scene.name}`");
            }
            else if (metadata.GameMode == null)
            {
                FLog.Warning(CLASS_TYPE.Name, $"GameMode is not sat for this level.");
            }
            else
            {
                CurrentGameMode = Activator.CreateInstance(metadata.GameMode.Type) as IGameMode;

                await CurrentGameMode?.PreInitializeAsync();
                await CurrentGameMode?.InitializeAsync();
                await CurrentGameMode?.BeginPlayAsync();

                FEventManager.Publish(FDefaultEventNameHelper.ON_GAME_MODE_LOADED);
            }
        }

        private async void OnSceneUnloaded(EventArgs arg)
        {
            await CurrentGameMode.UninitializeAsync();

            CurrentGameMode = null;
        }
        #endregion

        #region IGameManagement Implementation
        IGameMode IGameManagement.CurrentGameMode => CurrentGameMode;
        #endregion
    }
}
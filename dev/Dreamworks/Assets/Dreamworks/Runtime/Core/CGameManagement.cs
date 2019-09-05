/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using System.Threading.Tasks;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.Utility;
using DreamMachineGameStudio.Dreamworks.ServiceLocator;
using DreamMachineGameStudio.Dreamworks.EventManagement;
using DreamMachineGameStudio.Dreamworks.SceneManagement;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/31/2018</CreationDate>
    public abstract class CGameManagement : CComponent, IGameManagement
    {
        #region Field
        private IEventManagement eventManagement;
        #endregion

        #region Property
        public new static Type CLASS_TYPE => typeof(CGameManagement);

        protected IGameMode CurrentGameMode { get; private set; }
        #endregion

        #region Method
        protected async override Task InitializeComponentAsync()
        {
            await base.InitializeComponentAsync();

            MakePersistent();

            eventManagement = FServiceLocator.Resolve<IEventManagement>();

            eventManagement.Subscribe(FDefaultEventNameHelper.ON_SCENE_LOADED, OnSceneLoaded);
            eventManagement.Subscribe(FDefaultEventNameHelper.ON_SCENE_UNLOADED, OnSceneUnloaded);
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

            SSceneMetadata metadata = Resources.Load<SSceneMetadata>($"S{eventArg.Scene.name}");

            if (metadata == null)
            {
                FLog.LogWarning($"Cannot find scene metadata `S{eventArg.Scene.name}`", null, CLASS_TYPE.Name);
            }
            else if (string.IsNullOrEmpty(metadata.GameMode))
            {
                FLog.LogWarning($"GameMode is not sat for this level.", null, CLASS_TYPE.Name);
            }
            else
            {
                CurrentGameMode = Activator.CreateInstance(FReflectionUtility.GetType(metadata.GameMode)) as IGameMode;

                await CurrentGameMode?.PreInitializeAsync();
                await CurrentGameMode?.InitializeAsync();
                await CurrentGameMode?.BeginPlayAsync();

                eventManagement.Publish(FDefaultEventNameHelper.ON_GAME_MODE_LOADED);
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
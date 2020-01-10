/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Threading.Tasks;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.EventManager;
using DreamMachineGameStudio.Dreamworks.SceneManager;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    public sealed class CGameManagement : CComponent, IGameManagement
    {
        #region Fields
        private IGameMode currentGameMode;
        #endregion

        #region Property
        public new static Type CLASS_TYPE => typeof(CGameManagement);
        #endregion

        #region Method
        protected async override Task InitializeComponentAsync()
        {
            await base.InitializeComponentAsync();

            name = CLASS_TYPE.Name;

            MakePersistent();

            FEventManager.Subscribe(FDefaultEventNameHelper.ON_SCENE_LOADED, OnSceneLoaded);
            FEventManager.Subscribe(FDefaultEventNameHelper.ON_SCENE_UNLOADED, OnSceneUnloaded);
        }

        protected override void TickComponent(float deltaTime)
        {
            base.TickComponent(deltaTime);

            if (currentGameMode == null) return;

            if (currentGameMode.HasInitialized == false) return;

            if (currentGameMode.HasInitialized && currentGameMode.HasBeganPlay == false && currentGameMode.CanTickBeforePlay == false) return;

            currentGameMode.Tick(deltaTime);
        }

        protected override void LateTickComponent(float deltaTime)
        {
            base.LateTickComponent(deltaTime);

            if (currentGameMode == null) return;

            if (currentGameMode.HasInitialized == false) return;

            if (currentGameMode.HasInitialized && currentGameMode.HasBeganPlay == false && currentGameMode.CanLateTickBeforePlay == false) return;

            currentGameMode.LateTick(deltaTime);
        }

        protected override void FixedTickComponent(float deltaTime)
        {
            base.FixedTickComponent(deltaTime);

            if (currentGameMode == null) return;

            if (currentGameMode.HasInitialized == false) return;

            if (currentGameMode.HasInitialized && currentGameMode.HasBeganPlay == false && currentGameMode.CanFixedTickBeforePlay == false) return;

            currentGameMode.FixedTick(deltaTime);
        }
        #endregion

        #region Helpers
        private async void OnSceneLoaded(EventArgs arg)
        {
            FSceneLoadedEventArg eventArg = (FSceneLoadedEventArg)arg;

            CLevelConfiguration metadata = FindObjectOfType<CLevelConfiguration>();

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
                currentGameMode = Activator.CreateInstance(metadata.GameMode.Type) as IGameMode;

                await currentGameMode?.PreInitializeAsync();
                await currentGameMode?.InitializeAsync();
                await currentGameMode?.BeginPlayAsync();

                FEventManager.Publish(FDefaultEventNameHelper.ON_GAME_MODE_LOADED);
            }
        }

        private async void OnSceneUnloaded(EventArgs arg)
        {
            await currentGameMode.UninitializeAsync();

            currentGameMode = null;
        }
        #endregion

        #region IGameManagement Implementation
        IGameMode IGameManagement.CurrentGameMode => currentGameMode;
        #endregion
    }
}
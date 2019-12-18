/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0002

using System;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.EventManager;


#if UNITY_EDITOR
using SceneManager = UnityEditor.SceneManagement.EditorSceneManager;
#else
using SceneManager = UnityEngine.SceneManagement.SceneManager;
#endif


namespace DreamMachineGameStudio.Dreamworks.SceneManagement
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>June/24/2018</CreationDate>
    public sealed class CSceneManagement : CService, ISceneManagement
    {
        #region Property
        public new static Type CLASS_TYPE => typeof(CSceneManagement);
        #endregion

        #region Method
        protected async override Task InitializeComponentAsync()
        {
            await base.InitializeComponentAsync();

            name = nameof(CSceneManagement);

            SceneManager.activeSceneChanged += ActiveSceneChanged;
            SceneManager.sceneLoaded += SceneLoaded;
            SceneManager.sceneUnloaded += SceneUnloaded;

            MakePersistent();

#if UNITY_EDITOR
            /*
             * In Editor mode, Unity dose not send SceneLoaded event for open level after hitting play button.
             * To be able to play any level, we need a fake SceneLoaded for current open level.
            */
            FEventManager.Subscribe(FDefaultEventNameHelper.ON_INITIALIZATION, (_) => { SceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single); });
#endif
        }

        private async Task LoadSceneAsync(int sceneIndex, LoadSceneMode loadSceneMode)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, loadSceneMode);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{SceneManager.GetSceneByBuildIndex(sceneIndex).name}` has been loaded.");
        }

        private async Task LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{SceneManager.GetSceneByName(sceneName).name}` has been loaded.");
        }

        private async Task UnloadSceneAsycn(int sceneIndex)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneIndex);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{SceneManager.GetSceneByBuildIndex(sceneIndex).name}` has been unloaded.");
        }

        private async Task UnloadSceneAsycn(string sceneName)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{SceneManager.GetSceneByName(sceneName).name}` has been unloaded.");
        }

        private async Task UnloadSceneAsycn(Scene scene)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(scene);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{scene.name}` has been unloaded.");
        }
        #endregion

        #region Helpers
        private void ActiveSceneChanged(Scene replacedScene, Scene nextScene)
        {
            FEventManager.Publish(FDefaultEventNameHelper.ON_ACTIVE_SCENE_CHANGED, new FActiveSceneChangedEventArg(replacedScene, nextScene));
        }

        private void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            FEventManager.Publish(FDefaultEventNameHelper.ON_SCENE_LOADED, new FSceneLoadedEventArg(scene, loadSceneMode));
        }

        private void SceneUnloaded(Scene scene)
        {
            FEventManager.Publish(FDefaultEventNameHelper.ON_SCENE_UNLOADED, new FSceneUnloadedEventArg(scene));
        }
        #endregion

        #region ISceneManagement Implementation
        async Task ISceneManagement.LoadSceneAsync(int sceneIndex, LoadSceneMode loadSceneMode) => await LoadSceneAsync(sceneIndex, loadSceneMode);

        async Task ISceneManagement.LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode) => await LoadSceneAsync(sceneName, loadSceneMode);

        async Task ISceneManagement.UnloadSceneAsync(int sceneIndex) => await UnloadSceneAsycn(sceneIndex);

        async Task ISceneManagement.UnloadSceneAsync(string sceneName) => await UnloadSceneAsycn(sceneName);

        async Task ISceneManagement.UnloadSceneAsync(Scene scene) => await UnloadSceneAsycn(scene);
        #endregion
    }
}
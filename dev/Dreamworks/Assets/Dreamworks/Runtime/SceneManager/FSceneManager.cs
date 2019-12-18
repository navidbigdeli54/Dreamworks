/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0002

using System;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.EventManager;

using USceneManager = UnityEngine.SceneManagement.SceneManager;


namespace DreamMachineGameStudio.Dreamworks.SceneManagement
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>June/24/2018</CreationDate>
    public sealed class FSceneManager
    {
        #region Fields
        public readonly static Type CLASS_TYPE = typeof(FSceneManager);
        #endregion

        #region Constructor
        static FSceneManager()
        {
            USceneManager.activeSceneChanged += ActiveSceneChanged;
            USceneManager.sceneLoaded += SceneLoaded;
            USceneManager.sceneUnloaded += SceneUnloaded;
        }
        #endregion

        #region Method
        public async Task LoadSceneAsync(int sceneIndex, LoadSceneMode loadSceneMode)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = USceneManager.LoadSceneAsync(sceneIndex, loadSceneMode);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{USceneManager.GetSceneByBuildIndex(sceneIndex).name}` has been loaded.");
        }

        public async Task LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = USceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{USceneManager.GetSceneByName(sceneName).name}` has been loaded.");
        }

        public async Task UnloadSceneAsycn(int sceneIndex)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = USceneManager.UnloadSceneAsync(sceneIndex);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{USceneManager.GetSceneByBuildIndex(sceneIndex).name}` has been unloaded.");
        }

        public async Task UnloadSceneAsycn(string sceneName)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = USceneManager.UnloadSceneAsync(sceneName);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{USceneManager.GetSceneByName(sceneName).name}` has been unloaded.");
        }

        public async Task UnloadSceneAsycn(Scene scene)
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            AsyncOperation asyncOperation = USceneManager.UnloadSceneAsync(scene);

            asyncOperation.completed += (AsyncOperation ao) => taskCompletionSource.SetResult(ao.isDone);

            await taskCompletionSource.Task;

            FLog.Log(CLASS_TYPE.Name, $"Scene `{scene.name}` has been unloaded.");
        }
        #endregion

        #region Private Methods
        private static void ActiveSceneChanged(Scene replacedScene, Scene nextScene)
        {
            FEventManager.Publish(FDefaultEventNameHelper.ON_ACTIVE_SCENE_CHANGED, new FActiveSceneChangedEventArg(replacedScene, nextScene));
        }

        private static void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            FEventManager.Publish(FDefaultEventNameHelper.ON_SCENE_LOADED, new FSceneLoadedEventArg(scene, loadSceneMode));
        }

        private static void SceneUnloaded(Scene scene)
        {
            FEventManager.Publish(FDefaultEventNameHelper.ON_SCENE_UNLOADED, new FSceneUnloadedEventArg(scene));
        }
        #endregion
    }
}
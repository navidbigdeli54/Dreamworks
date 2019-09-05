/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.SceneManagement
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>June/24/2018</CreationDate>
    public interface ISceneManagement : IService
    {
        #region Method
        Task LoadSceneAsync(int sceneIndex, LoadSceneMode loadSceneMode);

        Task LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode);

        Task UnloadSceneAsync(int sceneIndex);

        Task UnloadSceneAsync(string sceneName);

        Task UnloadSceneAsync(Scene scene);
        #endregion
    }
}
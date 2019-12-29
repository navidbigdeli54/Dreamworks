/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine.SceneManagement;

namespace DreamMachineGameStudio.Dreamworks.SceneManagement
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>August/8/2019</CreationDate>
    public class FSceneLoadedEventArg : EventArgs
    {
        #region Property
        public readonly Scene Scene;

        public readonly LoadSceneMode LoadMode;
        #endregion

        #region Constructor
        public FSceneLoadedEventArg(Scene scene, LoadSceneMode loadMode)
        {
            Scene = scene;
            LoadMode = loadMode;
        }
        #endregion
    }
}

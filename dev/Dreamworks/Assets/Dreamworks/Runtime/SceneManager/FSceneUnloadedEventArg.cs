/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine.SceneManagement;

namespace DreamMachineGameStudio.Dreamworks.SceneManagement
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>August/8/2019</CreationDate>
    public class FSceneUnloadedEventArg : EventArgs
    {
        #region Property
        public Scene Scene { get; }
        #endregion

        #region Constructor
        public FSceneUnloadedEventArg(Scene scene) => Scene = scene;
        #endregion
    }
}

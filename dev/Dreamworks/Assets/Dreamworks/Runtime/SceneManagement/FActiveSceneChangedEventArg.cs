﻿/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine.SceneManagement;

namespace DreamMachineGameStudio.Dreamworks.SceneManagement
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>August/8/2019</CreationDate>
    public class FActiveSceneChangedEventArg : EventArgs
    {
        #region Property
        public Scene ReplacedScene { get; }

        public Scene NextScene { get; }
        #endregion

        #region Constructor
        public FActiveSceneChangedEventArg(Scene replacedScene, Scene nextScene)
        {
            ReplacedScene = replacedScene;

            NextScene = nextScene;
        }
        #endregion
    }
}

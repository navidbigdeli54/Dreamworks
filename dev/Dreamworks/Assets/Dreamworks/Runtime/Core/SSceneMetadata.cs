/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Attributes;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>June/24/2018</CreationDate>
    [TScriptableObjectWizard]
    public class SSceneMetadata : SScriptableObject
    {
        #region Field
        [SerializeField]
        private string gameMode;
        #endregion

        #region Property
        public string GameMode => gameMode;
        #endregion
    }
}
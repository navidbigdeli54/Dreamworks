/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using UnityEngine;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>December/18/2019</CreationDate>
    public class CLevelConfig : CComponent
    {
        #region Fields
        [SerializeField]
        [ASubclassFilter(typeof(CComponent))]
        private FSubclass gameMode;
        #endregion

        #region Properties
        public FSubclass GameMode => gameMode;
        #endregion
    }
}
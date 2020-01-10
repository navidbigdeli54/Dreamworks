/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using UnityEngine;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    public class CLevelConfiguration : CComponent
    {
        #region Fields
        [SerializeField]
        [ASubclassFilter(typeof(FGameMode))]
        private FSubclass gameMode;
        #endregion

        #region Properties
        public FSubclass GameMode => gameMode;
        #endregion
    }
}
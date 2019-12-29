/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

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
        [ATypeFilter(typeof(CComponent))]
        private FType gameMode;
        #endregion

        #region Properties
        public FType GameMode => gameMode;
        #endregion
    }
}
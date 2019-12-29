/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System;
using UnityEngine;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    [Serializable]
    public class FType
    {
        #region Fields
        [SerializeField]
        private string fullName;
        #endregion

        #region Property
        public string FullName => fullName;
        #endregion
    }
}
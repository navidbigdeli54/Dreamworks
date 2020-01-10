/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Utility;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    [Serializable]
    public sealed class FSubclass
    {
        #region Fields
        [SerializeField]
        private string fullName;
        #endregion

        #region Property
        public Type Type => FReflectionUtility.GetType(fullName);
        #endregion
    }
}
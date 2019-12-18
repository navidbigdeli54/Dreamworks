/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0044 // Add readonly modifier

using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Attributes;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>February/5/2019</CreationDate>
    [AScriptableObjectWizard]
    public class SFrameworkConfiguration : SScriptableObject
    {
        #region Field
        [SerializeField]
        private bool dontLoadFramework = false;

        [SerializeField]
        private string startupClass = string.Empty;
        #endregion

        #region Property
        public bool DontLoadFramework => dontLoadFramework;

        public string StartupClass => startupClass;
        #endregion
    }
}
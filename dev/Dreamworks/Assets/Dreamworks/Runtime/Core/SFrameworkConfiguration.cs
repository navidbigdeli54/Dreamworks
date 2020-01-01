/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable CS0649

using System;
using UnityEngine;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>February/5/2019</CreationDate>
    [AScriptableObjectWizard("Framework Configuration")]
    public class SFrameworkConfiguration : SScriptableObject
    {
        #region Field
        [SerializeField]
        private bool dontLoadFramework = false;

        [SerializeField]
        [ASubclassFilter(typeof(SStartup))]
        private FSubclass startupClass;
        #endregion

        #region Property
        public bool DontLoadFramework => dontLoadFramework;

        public Type StartupClass => startupClass.Type;
        #endregion
    }
}
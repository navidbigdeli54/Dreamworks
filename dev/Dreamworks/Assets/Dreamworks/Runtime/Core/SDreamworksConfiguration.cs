/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0044
#pragma warning disable CS0649

using System;
using UnityEngine;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    [AScriptableObjectWizard("Dreamworks Configuration")]
    public class SDreamworksConfiguration : SScriptableObject
    {
        #region Field
        [SerializeField]
        private bool dontLoadFramework = false;

        [SerializeField]
        [ASubclassFilter(typeof(FStartup))]
        private FSubclass startupClass;
        #endregion

        #region Property
        public bool DontLoadFramework => dontLoadFramework;

        public Type StartupClass => startupClass.Type;
        #endregion
    }
}
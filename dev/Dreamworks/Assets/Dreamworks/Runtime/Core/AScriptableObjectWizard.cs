/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Diagnostics;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    [Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Class)]
    public class AScriptableObjectWizard : AName
    {
        #region Fields
        public new static readonly Type CLASS_TYPE = typeof(AScriptableObjectWizard);
        #endregion

        #region Constructors
        public AScriptableObjectWizard(string name) : base(name) { }
        #endregion
    }
}
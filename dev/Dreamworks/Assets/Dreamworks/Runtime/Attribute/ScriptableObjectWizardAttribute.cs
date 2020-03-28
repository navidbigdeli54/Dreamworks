/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Diagnostics;

namespace DreamMachineGameStudio.Dreamworks
{
    [Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.Class)]
    public class ScriptableObjectWizardAttribute : NameAttribute
    {
        #region Fields
        public new static readonly Type CLASS_TYPE = typeof(ScriptableObjectWizardAttribute);
        #endregion

        #region Constructors
        public ScriptableObjectWizardAttribute(string name) : base(name) { }
        #endregion
    }
}
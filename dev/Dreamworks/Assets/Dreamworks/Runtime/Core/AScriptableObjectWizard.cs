/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>February/5/2019</CreationDate>
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
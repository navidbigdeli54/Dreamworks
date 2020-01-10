/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Diagnostics;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    [Conditional("UNITY_EDITOR")]
    [AttributeUsage(AttributeTargets.All)]
    public class AName : Attribute
    {
        #region Fields
        public static Type CLASS_TYPE = typeof(AName);
        #endregion

        #region Properties
        public string Name { get; }
        #endregion

        #region Constructors
        public AName(string name)
        {
            Name = name;
        }
        #endregion
    }
}
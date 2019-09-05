/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;

namespace DreamMachineGameStudio.Dreamworks.Test.Dummy.Utility
{
    /// <summary>
    /// A Dummy attribute for reflection test purpose
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/16/2019</CreationDate>
    [AttributeUsage(AttributeTargets.Class)]
    public class TReflectionDummy : Attribute
    {
        #region Property
        public string Name { get; }
        #endregion

        #region Constructor
        public TReflectionDummy() { }

        public TReflectionDummy(string name)
        {
            Name = name;
        }
        #endregion
    }
}
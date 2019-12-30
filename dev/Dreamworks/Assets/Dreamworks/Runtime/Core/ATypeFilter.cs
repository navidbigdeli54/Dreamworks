/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>December/19/2019</CreationDate>
    public class ATypeFilter : Attribute
    {
        #region Fields
        public readonly static Type CLASS_TYPE = typeof(ATypeFilter);
        #endregion

        #region Property
        public Type Type { get; }
        #endregion

        #region Constructor
        public ATypeFilter(Type type)
        {
            Type = type;
        }
        #endregion
    }
}
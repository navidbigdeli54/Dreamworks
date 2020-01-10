﻿/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    public class ASubclassFilter : Attribute
    {
        #region Fields
        public readonly static Type CLASS_TYPE = typeof(ASubclassFilter);
        #endregion

        #region Property
        public Type Type { get; }
        #endregion

        #region Constructor
        public ASubclassFilter(Type type)
        {
            Type = type;
        }
        #endregion
    }
}
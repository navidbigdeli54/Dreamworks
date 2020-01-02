﻿/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Graph
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/2/2020</CreationDate>
    [AttributeUsage(AttributeTargets.Field)]
    public class AOutput : AName
    {
        #region Constructors
        public AOutput(string name) : base(name) { }
        #endregion
    }
}
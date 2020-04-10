/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using UnityEngine;

namespace DreamMachineGameStudio.Dreamworks.Graph
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/2/2020</CreationDate>
    public abstract class SGraph : SScriptableObject
    {
        #region Fields
        [SerializeField]
        private List<SNode> _nodes = new List<SNode>();
        #endregion
    }
}
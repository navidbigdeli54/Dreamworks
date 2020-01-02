/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Graph
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/2/2020</CreationDate>
    public abstract class SNode : SScriptableObject
    {
        #region Fields
        [SerializeField]
        private SGraph graph;

        [SerializeField]
        private Vector2Int position;

        [SerializeField]
        private FNodePortDictionary ports = new FNodePortDictionary();
        #endregion

        #region Methods
        protected virtual void OnEnable() { }

        protected virtual void OnDestroy() { }
        #endregion
    }
}
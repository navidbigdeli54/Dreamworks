/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Graph
{
    public abstract class SNode : SScriptableObject
    {
        #region Fields
        [SerializeField]
        private SGraph _graph;

        [SerializeField]
        private Vector2Int _position;

        [SerializeField]
        private FNodePortDictionary _ports = new FNodePortDictionary();
        #endregion

        #region Methods
        protected virtual void OnEnable() { }

        protected virtual void OnDestroy() { }
        #endregion
    }
}
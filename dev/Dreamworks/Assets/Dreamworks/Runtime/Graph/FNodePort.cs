/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace DreamMachineGameStudio.Dreamworks.Graph
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/2/2020</CreationDate>
    [Serializable]
    public class FNodePort
    {
        #region Fields
        [SerializeField]
        [HideInInspector]
        private SNode node;

        [SerializeField]
        [HideInInspector]
        private List<FPortConnection> connections = new List<FPortConnection>();
        #endregion
    }
}
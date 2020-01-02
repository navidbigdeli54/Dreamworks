/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Graph
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/2/2020</CreationDate>
    [SerializeField]
    public sealed class FNodePortDictionary : Dictionary<string, FNodePort>, ISerializationCallbackReceiver
    {
        #region ISerializationCallbackReceiver Implementation
        [SerializeField]
        [HideInInspector]
        private List<string> keys = new List<string>();

        [SerializeField]
        [HideInInspector]
        private List<FNodePort> values = new List<FNodePort>();

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();

            foreach (KeyValuePair<string, FNodePort> item in this)
            {
                keys.Add(item.Key);
                values.Add(item.Value);
            }
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            FAssert.AreEqual(keys.Count, values.Count, $"There are {keys.Count} keys and {values.Count} values after deserialization. Make sure all of your types are serializable.");

            Clear();

            for (int i = 0; i < keys.Count; i++)
            {
                Add(keys[i], values[i]);
            }
        }
        #endregion
    }
}
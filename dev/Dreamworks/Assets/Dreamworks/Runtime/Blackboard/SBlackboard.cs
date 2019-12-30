/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System;
using UnityEngine;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    public sealed class SBlackboard : SScriptableObject, ISerializationCallbackReceiver
    {
        #region Fields
        [SerializeField]
        private SBlackboard parent;

        private readonly Dictionary<string, SValue> blackboard = new Dictionary<string, SValue>(StringComparer.OrdinalIgnoreCase);
        #endregion

        #region Methods
        public T GetValueSafe<T>(string name) where T : SValue
        {
            FAssert.IsFalse(string.IsNullOrWhiteSpace(name), $"`name` parameter can't be null.");

            blackboard.TryGetValue(name, out SValue value);

            if (value == null)
            {
                SBlackboard ancestor = parent;

                while (ancestor != null)
                {
                    value = ancestor.GetValueSafe<T>(name);

                    if (value != null) break;

                    ancestor = ancestor.parent;
                }
            }

            return (T)value;
        }
        #endregion

        #region ISerializationCallbackReceiver Implementation
        [SerializeField]
        private List<string> keys = new List<string>();

        [SerializeField]
        private List<SValue> values = new List<SValue>();

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();

            foreach (var item in blackboard)
            {
                keys.Add(item.Key);
                values.Add(item.Value);
            }
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            FAssert.AreEqual(keys.Count, values.Count);

            blackboard.Clear();

            for (int i = 0; i < keys.Count; i++)
            {
                blackboard.Add(keys[i], values[i]);
            }
        }
        #endregion
    }
}
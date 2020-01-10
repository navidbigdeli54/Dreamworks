﻿/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    public sealed class FBlackboard
    {
        #region Fields
        private readonly Dictionary<FStringId, IValue> values = new Dictionary<FStringId, IValue>();
        #endregion

        #region Methods
        public void AddValue<T>(FStringId key, T value) where T : class, IValue
        {
            FAssert.IsFalse(string.IsNullOrWhiteSpace(key), $"Name can't be null or empty.");
            FAssert.IsFalse(values.ContainsKey(key), $"A value with {key} key is already exist in blackboard.");

            values.Add(key, value);
        }

        public T GetValue<T>(FStringId key) where T : class, IValue
        {
            FAssert.IsTrue(values.ContainsKey(key), $"{key} key does not exist in the blackboard");

            return (T)values[key];
        }

        public bool TryGetValue<T>(FStringId key, out T value) where T : class, IValue
        {
            bool isSuccessful = values.TryGetValue(key, out IValue result);

            value = result as T;

            return isSuccessful;
        }
        #endregion
    }
}
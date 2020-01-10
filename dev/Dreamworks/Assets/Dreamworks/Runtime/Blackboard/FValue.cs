/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    public abstract class FValue<T> : IValue
    {
        #region Fields
        public static readonly Type CLASS_TYPE = typeof(FValue<>);

        [SerializeField]
        protected T value;

        [SerializeField]
        protected readonly bool isReadOnly;
        #endregion

        #region Constructors
        public FValue() { }

        public FValue(T value) => this.value = value;

        public FValue(bool isReadOnly, T value)
        {
            this.value = value;
            this.isReadOnly = isReadOnly;
        }
        #endregion

        #region Properties
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (isReadOnly)
                {
                    FLog.Error(CLASS_TYPE.Name, $"Value is read-only but you trying to assign a new value.");
                    return;
                }

                this.value = value;
            }
        }
        #endregion

        #region IValue Implementation
        bool IValue.IsReadOnly => isReadOnly;
        #endregion
    }
}
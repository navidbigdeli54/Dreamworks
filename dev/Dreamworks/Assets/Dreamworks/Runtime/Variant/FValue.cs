/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Variant
{
    [Serializable]
    public abstract class FValue<T> : IValue
    {
        #region Fields
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
                    FLog.Error(nameof(FValue<T>), $"Value is read-only but you trying to assign a new value.");
                    return;
                }

                this.value = value;
            }
        }
        #endregion

        #region Protected Methods
        protected abstract bool Equals(IValue other);

        protected abstract int CompareTo(IValue other);
        #endregion

        #region IValue Implementation
        bool IValue.IsReadOnly => isReadOnly;
        #endregion

        #region IEquatable Implementation
        bool IEquatable<IValue>.Equals(IValue other) => Equals(other);
        #endregion

        #region IComprable Implementation
        int IComparable<IValue>.CompareTo(IValue other) => CompareTo(other);
        #endregion
    }
}
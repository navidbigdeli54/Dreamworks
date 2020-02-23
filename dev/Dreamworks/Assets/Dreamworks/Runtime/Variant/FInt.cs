/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Variant
{
    [AName("Int")]
    [Serializable]
    public sealed class FInt : FValue<int>
    {
        #region Constructors
        public FInt(int value) : base(value) { }

        public FInt(bool isReadOnly, int value) : base(isReadOnly, value) { }
        #endregion

        #region Public Methods
        public override bool Equals(object obj)
        {
            FInt i = obj as FInt;
            FAssert.IsNotNull(i, $"Given object is not an {nameof(FInt)}");

            if (obj == null || i == null)
            {
                return false;
            }
            else if ((object)this == obj)
            {
                return true;
            }
            else
            {
                return value == i.value;
            }
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
        #endregion

        #region Protected Methods
        protected override bool Equals(IValue other)
        {
            FInt castedOther = other as FInt;
            FAssert.IsNotNull(castedOther, "Other is not FBool type.");

            return this.value == castedOther.value;
        }

        protected override int CompareTo(IValue other)
        {
            FInt castedOther = other as FInt;
            FAssert.IsNotNull(castedOther, "Other is not FBool type.");

            return value.CompareTo(castedOther.value);
        }
        #endregion

        #region Operator Overloading
        public static implicit operator FInt(int i) => new FInt(i);

        public static implicit operator int(FInt i) => i.value;

        public static bool operator ==(FInt lhs, FInt rhs) => Equals(rhs, lhs);

        public static bool operator !=(FInt lhs, FInt rhs) => !Equals(rhs, lhs);

        public static bool Equals(FInt lhs, FInt rhs)
        {
            if ((object)lhs == rhs)
            {
                return true;
            }
            else if (null == lhs || null == rhs)
            {
                return false;
            }
            else
            {
                return rhs.value == lhs.value;
            }
        }
        #endregion
    }
}
/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Variant
{
    [AName("Float")]
    [Serializable]
    public sealed class FFloat : FValue<float>
    {
        #region Constructors
        public FFloat(float value) : base(value) { }

        public FFloat(bool isReadonly, float value) : base(isReadonly, value) { }
        #endregion

        #region Public Methods
        public override bool Equals(object obj)
        {
            FFloat f = obj as FFloat;
            FAssert.IsNotNull(f, $"Given object is not an {nameof(FFloat)}");

            if (obj == null || f == null)
            {
                return false;
            }
            else if ((object)this == obj)
            {
                return true;
            }
            else
            {
                return value == f.value;
            }
        }

        public override int GetHashCode() => value.GetHashCode();
        #endregion

        #region Protected Methods
        protected override bool Equals(IValue other)
        {
            FFloat castedOther = other as FFloat;
            FAssert.IsNotNull(castedOther, "Other is not FBool type.");

            return this.value == castedOther.value;
        }

        protected override int CompareTo(IValue other)
        {
            FFloat castedOther = other as FFloat;
            FAssert.IsNotNull(castedOther, "Other is not FBool type.");

            return value.CompareTo(castedOther.value);
        }
        #endregion

        #region Operator Overloading
        public static implicit operator FFloat(float f) => new FFloat(f);

        public static implicit operator float(FFloat f) => f.value;

        public static bool operator ==(FFloat lhs, FFloat rhs) => Equals(rhs, lhs);

        public static bool operator !=(FFloat lhs, FFloat rhs) => !Equals(rhs, lhs);

        public static bool Equals(FFloat lhs, FFloat rhs)
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
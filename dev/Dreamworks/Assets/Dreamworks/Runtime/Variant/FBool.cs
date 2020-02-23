/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Variant
{
    [AName("Bool")]
    [Serializable]
    public sealed class FBool : FValue<bool>
    {
        #region Constructors
        public FBool(bool value = false) : base(value) { }

        public FBool(bool isReadonly, bool value) : base(isReadonly, value) { }
        #endregion

        #region Public Methods
        public override bool Equals(object obj)
        {
            FBool b = obj as FBool;
            FAssert.IsNotNull(b, $"Given object is not an {nameof(FBool)}");

            if (obj == null || b == null)
            {
                return false;
            }
            else if ((object)this == obj)
            {
                return true;
            }
            else
            {
                return value == b.value;
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
            FBool castedOther = other as FBool;
            FAssert.IsNotNull(castedOther, "Other is not FBool type.");

            return this.value == castedOther.value;
        }

        protected override int CompareTo(IValue other)
        {
            FBool castedOther = other as FBool;
            FAssert.IsNotNull(castedOther, "Other is not FBool type.");

            if (this.value == castedOther.value)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region Operator Overloading
        public static implicit operator FBool(bool b) => new FBool(b);

        public static implicit operator bool(FBool b) => b.value;

        public static bool operator ==(FBool lhs, FBool rhs)
        {
            return Equals(rhs, lhs);
        }

        public static bool operator !=(FBool lhs, FBool rhs)
        {
            return !Equals(rhs, lhs);
        }

        public static bool Equals(FBool lhs, FBool rhs)
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
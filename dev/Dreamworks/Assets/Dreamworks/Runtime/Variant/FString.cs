/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Variant
{
    [Serializable]
    [AName("String")]
    public sealed class FString : FValue<string>
    {
        #region Constructors
        public FString(string value) : base(value) { }

        public FString(bool isReadonly, string value) : base(isReadonly, value) { }
        #endregion

        #region Public Methods
        public override bool Equals(object obj)
        {
            FString i = obj as FString;
            FAssert.IsNotNull(i, $"Given object is not an {nameof(FString)}");

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
            FString castedOther = other as FString;
            FAssert.IsNotNull(castedOther, "Other is not FBool type.");

            return this.value == castedOther.value;
        }

        protected override int CompareTo(IValue other)
        {
            FString castedOther = other as FString;
            FAssert.IsNotNull(castedOther, "Other is not FBool type.");

            return value.CompareTo(castedOther.value);
        }
        #endregion

        #region Operator Overloading
        public static implicit operator FString(string str) => new FString(str);

        public static implicit operator string(FString str) => str.value;

        public static bool operator ==(FString lhs, FString rhs) => Equals(rhs, lhs);

        public static bool operator !=(FString lhs, FString rhs) => !Equals(rhs, lhs);

        public static bool Equals(FString lhs, FString rhs)
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
                return rhs.value.Equals(rhs);
            }
        }
        #endregion
    }
}
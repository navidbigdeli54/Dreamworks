/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("String")]
    public sealed class FString : FValue<string>, IEquatable<FString>, IComparable<FString>
    {
        #region Constructors
        public FString(string value) : base(value) { }

        public FString(bool isReadonly, string value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FString> Implementation
        bool IEquatable<FString>.Equals(FString other) => value == other.value;
        #endregion

        #region IComparable<FString> Implementation
        int IComparable<FString>.CompareTo(FString other) => value.CompareTo(other.value);
        #endregion
    }
}
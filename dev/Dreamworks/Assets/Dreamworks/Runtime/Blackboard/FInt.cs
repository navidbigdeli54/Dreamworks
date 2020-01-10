/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Int")]
    public sealed class FInt : FValue<int>, IEquatable<FInt>, IComparable<FInt>
    {
        #region Constructors
        public FInt(int value) : base(value) { }

        public FInt(bool isReadOnly, int value) : base(isReadOnly, value) { }
        #endregion

        #region IEquatable<FInt> Implementation
        bool IEquatable<FInt>.Equals(FInt other) => value == other.value;
        #endregion

        #region IComparable<FInt> Implementation
        int IComparable<FInt>.CompareTo(FInt other) => value.CompareTo(other.value);
        #endregion
    }
}
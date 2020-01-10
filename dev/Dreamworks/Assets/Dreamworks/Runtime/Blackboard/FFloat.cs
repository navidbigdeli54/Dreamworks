/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Float")]
    public sealed class FFloat : FValue<float>, IEquatable<FFloat>, IComparable<FFloat>
    {
        #region Constructors
        public FFloat(float value) : base(value) { }

        public FFloat(bool isReadonly, float value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FFloat> Implementation
        bool IEquatable<FFloat>.Equals(FFloat other) => value == other.value;
        #endregion

        #region IComparable<FFloat> Implementation
        int IComparable<FFloat>.CompareTo(FFloat other) => value.CompareTo(other.value);
        #endregion
    }
}
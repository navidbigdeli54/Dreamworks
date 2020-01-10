/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Double")]
    public sealed class FDouble : FValue<FDouble>, IEquatable<FDouble>
    {
        #region Constructors
        public FDouble(FDouble value) : base(value) { }

        public FDouble(bool isReadonly, FDouble value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FDouble> Implementation
        bool IEquatable<FDouble>.Equals(FDouble other) => value == other.value;
        #endregion
    }
}
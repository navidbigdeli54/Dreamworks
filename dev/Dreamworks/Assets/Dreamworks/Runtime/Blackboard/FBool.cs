/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Bool")]
    public sealed class FBool : FValue<bool>, IEquatable<FBool>
    {
        #region Constructors
        public FBool(bool value) : base(value) { }

        public FBool(bool isReadonly, bool value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FBool> Implementation
        bool IEquatable<FBool>.Equals(FBool other) => value == other.value;
        #endregion
    }
}
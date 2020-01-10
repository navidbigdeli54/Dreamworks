/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Quaternion")]
    public sealed class FQuaternion : FValue<Quaternion>, IEquatable<FQuaternion>
    {
        #region Constructors
        public FQuaternion(Quaternion value) : base(value) { }

        public FQuaternion(bool isReadonly, Quaternion value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<Quaternion> Implementation
        bool IEquatable<FQuaternion>.Equals(FQuaternion other) => value == other.value;
        #endregion
    }
}
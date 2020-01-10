/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Vector3")]
    public sealed class FVector3 : FValue<Vector3>, IEquatable<FVector3>
    {
        #region Constructors
        public FVector3(Vector3 value) : base(value) { }

        public FVector3(bool isReadonly, Vector3 value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FVector3> Implementation
        bool IEquatable<FVector3>.Equals(FVector3 other) => value == other.value;
        #endregion
    }
}
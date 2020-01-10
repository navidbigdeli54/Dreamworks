/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Vector2")]
    public sealed class FVector2 : FValue<Vector2>, IEquatable<FVector2>
    {
        #region Constructors
        public FVector2(Vector2 value) : base(value) { }

        public FVector2(bool isReadonly, Vector2 value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FVector2> Implementation
        bool IEquatable<FVector2>.Equals(FVector2 other) => value == other.value;
        #endregion
    }
}
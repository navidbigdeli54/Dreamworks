/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Transform")]
    public sealed class FTransform : FValue<Transform>, IEquatable<FTransform>
    {
        #region Constructors
        public FTransform(Transform value) : base(value) { }

        public FTransform(bool isReadonly, Transform value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FUnityObject> Implementation
        bool IEquatable<FTransform>.Equals(FTransform other) => value == other.value;
        #endregion
    }
}
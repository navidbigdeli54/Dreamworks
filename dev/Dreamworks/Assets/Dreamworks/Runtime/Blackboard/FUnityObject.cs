/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Unity Object")]
    public sealed class FUnityObject : FValue<UnityEngine.Object>, IEquatable<FUnityObject>
    {
        #region Constructors
        public FUnityObject(UnityEngine.Object value) : base(value) { }

        public FUnityObject(bool isReadonly, UnityEngine.Object value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FUnityObject> Implementation
        bool IEquatable<FUnityObject>.Equals(FUnityObject other) => value == other.value;
        #endregion
    }
}
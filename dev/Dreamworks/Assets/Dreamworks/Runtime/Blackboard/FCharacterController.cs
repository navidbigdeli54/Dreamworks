/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("CharacterController")]
    public sealed class FCharacterController : FValue<CharacterController>, IEquatable<FCharacterController>
    {
        #region Constructors
        public FCharacterController(CharacterController value) : base(value) { }

        public FCharacterController(bool isReadonly, CharacterController value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FUnityObject> Implementation
        bool IEquatable<FCharacterController>.Equals(FCharacterController other) => value == other.value;
        #endregion
    }
}
/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("RigidBody")]
    public sealed class FRigidBody : FValue<Rigidbody>, IEquatable<FRigidBody>
    {
        #region Constructors
        public FRigidBody(Rigidbody value) : base(value) { }

        public FRigidBody(bool isReadonly, Rigidbody value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FUnityObject> Implementation
        bool IEquatable<FRigidBody>.Equals(FRigidBody other) => value == other.value;
        #endregion
    }
}
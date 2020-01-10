/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Animator")]
    public sealed class FAnimator : FValue<Animator>, IEquatable<FAnimator>
    {
        #region Constructors
        public FAnimator(Animator value) : base(value) { }

        public FAnimator(bool isReadonly, Animator value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FUnityObject> Implementation
        bool IEquatable<FAnimator>.Equals(FAnimator other) => value == other.value;
        #endregion
    }
}
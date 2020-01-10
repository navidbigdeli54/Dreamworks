/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.GamePlay;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    [Serializable]
    [AName("Health")]
    public sealed class FHealth : FValue<CHealth>, IEquatable<FHealth>
    {
        #region Constructors
        public FHealth(CHealth value) : base(value) { }

        public FHealth(bool isReadonly, CHealth value) : base(isReadonly, value) { }
        #endregion

        #region IEquatable<FUnityObject> Implementation
        bool IEquatable<FHealth>.Equals(FHealth other) => value == other.value;
        #endregion
    }
}
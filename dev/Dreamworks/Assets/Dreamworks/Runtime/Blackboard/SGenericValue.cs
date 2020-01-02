/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    public abstract class SGenericValue<T> : SValue
    {
        #region Fields
        public readonly Type CLASS_TYPE = typeof(SGenericValue<>);

        [SerializeField]
        protected T value;
        #endregion

        #region Properties
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                FAssert.IsTrue(IsReadOnly, $"The {name} property is read-only.");

                this.value = value;
            }
        }
        #endregion
    }
}
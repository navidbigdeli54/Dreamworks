/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.Blackboard;

namespace DreamMachineGameStudio.Dreamworks.Rule
{
    public sealed class FCriteria<T> : ICriteria where T : class, IValue
    {
        #region Fields
        private readonly FStringId key;

        private readonly T expectedValue;

        private readonly FBlackboard blackboard;

        private readonly EValueComparer comparer;
        #endregion

        #region Constructors
        public FCriteria(FBlackboard blackboard, FStringId key, EValueComparer comparer, T expectedValue)
        {
            this.key = key;
            this.comparer = comparer;
            this.blackboard = blackboard;
            this.expectedValue = expectedValue;
        }
        #endregion

        #region Private Methods
        private bool CheckEquality(T currentValue)
        {
            FAssert.AreEqual(expectedValue.GetType(), currentValue.GetType(), $"Expected value is {expectedValue.GetType().Name} but current value is {currentValue.GetType()}");

            if (currentValue == expectedValue) return true;

            FAssert.IsTrue(currentValue is IEquatable<T>, $"Value is not IEquatable type.");

            return ((IEquatable<T>)currentValue).Equals(expectedValue);
        }

        private int CompareValue(T currentValue)
        {
            FAssert.AreEqual(expectedValue.GetType(), currentValue.GetType(), $"Expected value is {expectedValue.GetType().Name} but current value is {currentValue.GetType()}");

            FAssert.IsTrue(currentValue is IComparable<T>, $"Value is not IEquatable type.");

            return ((IComparable<T>)currentValue).CompareTo(expectedValue);
        }
        #endregion

        #region ICriteria Implementation
        FStringId ICriteria.Key => key;

        EValueComparer ICriteria.Comparer => comparer;

        FBlackboard ICriteria.Blackboard => blackboard;

        bool ICriteria.Evaluate()
        {
            if (blackboard.TryGetValue(key, out T currentValue))
            {
                switch (comparer)
                {
                    case EValueComparer.Equal:
                        return CheckEquality(currentValue);
                    case EValueComparer.NotEqual:
                        return !CheckEquality(currentValue);
                    case EValueComparer.GreaterThan:
                        return CompareValue(currentValue) > 0;
                    case EValueComparer.GreaterThanEqual:
                        return CompareValue(currentValue) >= 0;
                    case EValueComparer.LessThan:
                        return CompareValue(currentValue) < 0;
                    case EValueComparer.LessThanEqual:
                        return CompareValue(currentValue) <= 0;
                }
            }

            return false;
        }
        #endregion
    }
}
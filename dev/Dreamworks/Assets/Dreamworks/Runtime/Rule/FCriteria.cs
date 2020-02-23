/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.Variant;
using DreamMachineGameStudio.Dreamworks.Blackboard;

namespace DreamMachineGameStudio.Dreamworks.Rule
{
    public sealed class FCriteria : ICriteria
    {
        #region Fields
        private readonly FStringId key;

        private readonly IValue expectedValue;

        private readonly EValueComparer comparer;

        private readonly FBlackboard blackboard;
        #endregion

        #region Constructors
        public FCriteria(FBlackboard blackboard, FStringId key, EValueComparer comparer, IValue expectedValue)
        {
            this.key = key;
            this.comparer = comparer;
            this.blackboard = blackboard;
            this.expectedValue = expectedValue;
        }
        #endregion

        #region Private Methods
        private bool CheckEquality(IValue currentValue)
        {
            FAssert.AreEqual(expectedValue.GetType(), currentValue.GetType(), $"Expected value is {expectedValue.GetType().Name} but current value is {currentValue.GetType()}");

            if (currentValue == expectedValue) return true;

            return currentValue.Equals(expectedValue);
        }

        private int CompareValue(IValue currentValue)
        {
            FAssert.AreEqual(expectedValue.GetType(), currentValue.GetType(), $"Expected value is {expectedValue.GetType().Name} but current value is {currentValue.GetType()}");

            return currentValue.CompareTo(expectedValue);
        }
        #endregion

        #region ICriteria Implementation
        FStringId ICriteria.Key => key;

        EValueComparer ICriteria.Comparer => comparer;

        FBlackboard ICriteria.Blackboard => blackboard;

        bool ICriteria.Evaluate()
        {
            if (blackboard.TryGetValue(key, out IValue currentValue))
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
/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Blackboard;

namespace DreamMachineGameStudio.Dreamworks.Rule
{
    public sealed class FRule
    {
        #region Fields
        private readonly List<ICriteria> criterias = new List<ICriteria>();
        #endregion

        #region Properties
        public FRespone Response { get; private set; }

        public IReadOnlyList<ICriteria> Criterias => criterias;
        #endregion

        #region Methods
        public FRule SetResponse(FRespone respone)
        {
            this.Response = respone;

            return this;
        }

        public FRule AddCriteria<T>(FBlackboard blackboard, FStringId key, T expectedValue) where T : class, IValue
        {
            criterias.Add(new FCriteria<T>(blackboard, key, EValueComparer.Equal, expectedValue));

            return this;
        }

        public FRule AddCriteria<T>(FBlackboard blackboard, FStringId key, EValueComparer comparer, T expectedValue) where T : class, IValue
        {
            criterias.Add(new FCriteria<T>(blackboard, key, comparer, expectedValue));

            return this;
        }

        public bool Evaluate()
        {
            for (int i = 0; i < criterias.Count; i++)
            {
                if (criterias[i].Evaluate() == false) return false;
            }

            return true;
        }
        #endregion
    }
}
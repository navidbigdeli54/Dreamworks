/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Blackboard;

namespace DreamMachineGameStudio.Dreamworks.Rule
{
    public interface ICriteria
    {
        #region Properties
        FStringId Key { get; }

        FBlackboard Blackboard { get; }

        EValueComparer Comparer { get; }
        #endregion

        #region Methods
        bool Evaluate();
        #endregion
    }
}
/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using DreamMachineGameStudio.Dreamworks.Blackboard;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Rule
{
    public interface ICriteria
    {
        #region Properties
        FStringId Key { get; }

        EValueComparer Comparer { get; }

        FBlackboard Blackboard { get; }
        #endregion

        #region Methods
        bool Evaluate();
        #endregion
    }
}
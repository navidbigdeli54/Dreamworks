/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Blackboard;

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public interface IHFSM : IPureInitializable, IPureTickable
    {
        #region Owner
        CHFSMBrain Owner { get; }

        FBlackboard Blackboard { get; }
        #endregion

        #region Methods
        void PushTrigger(FStringId trigger);

        void AddState<TState>(IState state) where TState : IState;

        TState GetState<TState>() where TState : IState;

        void Initial<TState>() where TState : FInitialState;
        #endregion
    }
}
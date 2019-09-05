/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.SFSM.Core
{
    public interface ISFSMBrain<TBrain> : ISFSM where TBrain : ISFSMBrain<TBrain>
    {
        #region Property
        ISFSMState<TBrain> CurrentState { get; }
        #endregion

        #region Method
        void PushState<TState>() where TState : ISFSMState<TBrain>;

        void PopState();

        void ChangeState<TState>() where TState : ISFSMState<TBrain>;
        #endregion
    }
}
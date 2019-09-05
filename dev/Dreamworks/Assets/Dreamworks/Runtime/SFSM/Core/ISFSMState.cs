/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System.Threading.Tasks;

namespace DreamMachineGameStudio.Dreamworks.SFSM.Core
{
    public interface ISFSMState<TBrain> : ISFSM where TBrain : ISFSMBrain<TBrain>
    {
        #region Property
        TBrain Owner { get; }
        #endregion

        #region Method
        void OnEnterEvent();

        void OnExitEvent();

        Task PreInitializeEventAsync();

        Task InitializeEventAsync();

        Task BeginPlayEventAsync();

        Task UninitializeEventAsync();

        void TickEvent(float deltaTime);

        void LateTickEvent(float deltaTime);

        void FixedTickEvent(float deltaTime);

        void OnDisableEvent();

        void OnEnableEvent();
        #endregion
    }
}
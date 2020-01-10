/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public interface ITransition
    {
        #region Field
        IState Target { get; }

        FStringId Trigger { get; }
        #endregion

        #region Methods
        bool CheckCondition();

        void PerformActions();
        #endregion
    }
}
/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public abstract class FInitialState : FState
    {
        #region Constructors
        public FInitialState(IHFSM hfsm) : base(hfsm) { }
        #endregion
    }
}
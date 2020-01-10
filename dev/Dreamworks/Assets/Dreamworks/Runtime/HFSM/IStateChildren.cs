/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System.Collections.Generic;

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public interface IStateChildren
    {
        #region Properties
        IReadOnlyList<IState> Children { get; }
        #endregion
    }
}
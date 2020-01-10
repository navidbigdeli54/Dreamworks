/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public interface IState : IPureTickable, IPureInitializable
    {
        #region Properties
        bool IsActive { get; }

        IState Parent { get; }
        #endregion

        #region Methods
        void OnEnter();

        void OnExit();

        ITransition CheckTransactions(FStringId trigger);

        IReadOnlyList<IState> GetAncestors();

        bool IsAncestor(IState state);
        #endregion
    }
}
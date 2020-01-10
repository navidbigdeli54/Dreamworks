/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.Blackboard;

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public sealed class FHFSM : IHFSM
    {
        #region Fields
        private const int INVALID_INDEX = -1;

        private readonly CHFSMBrain owner;

        private readonly FBlackboard blackboard;

        private readonly List<IState> activeStatesHierarchy = new List<IState>();

        private readonly Dictionary<Type, IState> registeredStates = new Dictionary<Type, IState>();

        private readonly List<IState> pendingAddStates = new List<IState>();

        private bool isPreInitializing;
        #endregion
        #region Constructor
        public FHFSM(CHFSMBrain owner)
        {
            this.owner = owner;
            this.blackboard = new FBlackboard();
        }
        #endregion

        #region Private Methods
        private void ActiveState(IState from, IState target, FStringId trigger)
        {
            if (from != null)
            {
                ExitStateHierarchyTo(from, target);
            }

            EnterStateHierarchyFrom(from, target, trigger);

            if (target.IsActive == false) return;

            if (trigger != null)
            {
                ITransition transaction = target.CheckTransactions(trigger);

                if (transaction != null)
                {
                    transaction.PerformActions();

                    ActiveState(target, transaction.Target, trigger);
                }
            }
        }

        private void EnterStateHierarchyFrom(IState from, IState target, FStringId trigger)
        {
            FAssert.IsNotNull(target, "Target state can't be null.");

            List<IState> statesToEnter = new List<IState>();

            IReadOnlyList<IState> ancestors = target.GetAncestors();
            for (int i = ancestors.Count - 1; i >= 0; i--)
            {
                IState currentState = ancestors[i];

                if (from != null && from.IsAncestor(currentState)) continue;

                statesToEnter.Add(currentState);
            }

            for (int i = 0; i < statesToEnter.Count; i++)
            {
                EnterState(statesToEnter[i], trigger);
            }

            EnterSubstates(target, trigger);
        }

        private void EnterSubstates(IState state, FStringId trigger)
        {
            if (state.IsActive == false) return;

            if (state is IParallelState parallelState)
            {
                IReadOnlyList<IState> substates = parallelState.Substates;
                for (int i = 0; i < substates.Count; i++)
                {
                    IState currentState = substates[i];
                    EnterState(currentState, trigger);
                    EnterSubstates(currentState, trigger);
                }
            }
            else if (state is IStateChildren stateChildren)
            {
                IReadOnlyList<IState> children = stateChildren.Children;

                for (int i = 0; i < children.Count; i++)
                {
                    if (children[i] is FInitialState initialState)
                    {
                        EnterState(initialState, trigger);
                        EnterSubstates(initialState, trigger);
                        break;
                    }
                }
            }
        }

        private void EnterState(IState state, FStringId trigger)
        {
            state.OnEnter();

            activeStatesHierarchy.Add(state);

            if (trigger != null)
            {
                ITransition transaction = state.CheckTransactions(trigger);

                if (transaction != null)
                {
                    transaction.PerformActions();

                    ActiveState(state, transaction.Target, trigger);
                }
            }
        }

        private void ExitStateHierarchyTo(IState from, IState target)
        {
            FAssert.IsNotNull(from, $"From state can't be null.");

            if (from is IParallelState parallelState)
            {
                for (int i = 0; i < parallelState.Substates.Count; i++)
                {
                    ExitStateHierarchyTo(parallelState.Substates[i], target);
                }
            }
            else
            {
                IReadOnlyList<IState> ancestors = from.GetAncestors();
                for (int i = 0; i < ancestors.Count; i++)
                {
                    IState currentState = ancestors[i];

                    if (target.IsAncestor(currentState)) break;

                    ExitSubstates(currentState, target);

                    ExitState(currentState, target);
                }
            }
        }

        private void ExitSubstates(IState state, IState target)
        {
            IReadOnlyList<IState> activeStatesAfter = GetReversedActiveStatesAfter(state);

            for (int i = 0; i < activeStatesAfter.Count; i++)
            {
                IState currentState = activeStatesAfter[i];

                if (target != null && target.IsAncestor(currentState)) continue;

                ExitState(currentState, target);
            }
        }

        private void ExitState(IState from, IState to)
        {
            FAssert.IsNotNull(from, "From state can't be null");

            if (from is IParallelState)
            {
                ExitSubstates(from, to);
            }

            from.OnExit();

            activeStatesHierarchy.Remove(from);
        }

        private IReadOnlyList<IState> GetReversedActiveStatesAfter(IState state)
        {
            int index = activeStatesHierarchy.IndexOf(state);
            FAssert.IsFalse(index == INVALID_INDEX, $"{state.Name} is not active.");

            List<IState> result = new List<IState>();

            for (int i = activeStatesHierarchy.Count - 1; i >= index; i--)
            {
                IState activeState = activeStatesHierarchy[i];

                if (activeState.IsAncestor(state))
                {
                    result.Add(activeState);
                }
            }

            return result;
        }
        #endregion

        #region IHFSM Implementation
        CHFSMBrain IHFSM.Owner => owner;

        FBlackboard IHFSM.Blackboard => blackboard;

        void IHFSM.PushTrigger(FStringId trigger)
        {
            FAssert.IsTrue(trigger != null, $"Invalid trigger");

            for (int i = 0; i < activeStatesHierarchy.Count; i++)
            {
                IState state = activeStatesHierarchy[i];

                ITransition transaction = state.CheckTransactions(trigger);

                if (transaction != null)
                {
                    transaction.PerformActions();

                    ActiveState(state, transaction.Target, trigger);

                    return;
                }
            }
        }

        void IHFSM.AddState<TState>(IState state)
        {
            FAssert.IsNotNull(state, "State can't be null");

            Type type = state.GetType();

            FAssert.IsFalse(registeredStates.ContainsKey(type), $"{state.Name} has already added into the HFSM");

            if (isPreInitializing)
            {
                pendingAddStates.Add(state);
            }
            else
            {
                registeredStates.Add(type, state);
            }
        }

        TState IHFSM.GetState<TState>()
        {
            Type stateType = typeof(TState);

            FAssert.IsTrue(registeredStates.ContainsKey(stateType), $"There is not state with {stateType.Name} type in HFSM.");

            return (TState)registeredStates[stateType];
        }

        void IHFSM.Initial<TState>()
        {
            Type stateType = typeof(TState);

            FAssert.IsTrue(registeredStates.ContainsKey(stateType), $"There is not state with {stateType.Name} type in HFSM.");

            IState initialState = registeredStates[stateType];

            ActiveState(null, initialState, null);
        }
        #endregion

        #region INameable Implementation
        string INameable.Name => owner.name;
        #endregion

        #region IPureInitializable Implementation
        async Task IPureInitializable.PreInitializeAsync()
        {
            isPreInitializing = true;

            foreach (KeyValuePair<Type, IState> state in registeredStates)
            {
                await state.Value.PreInitializeAsync();
            }

            for (int i = 0; i < pendingAddStates.Count; i++)
            {
                IState state = pendingAddStates[i];

                await state.PreInitializeAsync();

                FAssert.IsFalse(registeredStates.ContainsKey(state.GetType()), $"A state with type {state.GetType()} is already exist.");

                registeredStates.Add(state.GetType(), state);
            }

            isPreInitializing = false;
        }

        async Task IPureInitializable.InitializeAsync()
        {
            foreach (KeyValuePair<Type, IState> state in registeredStates)
            {
                await state.Value.InitializeAsync();
            }
        }

        async Task IPureInitializable.BeginPlayAsync()
        {
            foreach (KeyValuePair<Type, IState> state in registeredStates)
            {
                await state.Value.BeginPlayAsync();
            }
        }

        async Task IPureInitializable.UninitializeAsync()
        {
            foreach (KeyValuePair<Type, IState> state in registeredStates)
            {
                await state.Value.UninitializeAsync();
            }
        }
        #endregion

        #region IPureTickable Implementation

        void IPureTickable.Tick(float deltaTime)
        {
            for (int i = 0; i < activeStatesHierarchy.Count; i++)
            {
                activeStatesHierarchy[i].Tick(deltaTime);
            }
        }

        void IPureTickable.LateTick(float deltaTime)
        {
            for (int i = 0; i < activeStatesHierarchy.Count; i++)
            {
                activeStatesHierarchy[i].LateTick(deltaTime);
            }
        }

        void IPureTickable.FixedTick(float deltaTime)
        {
            for (int i = 0; i < activeStatesHierarchy.Count; i++)
            {
                activeStatesHierarchy[i].FixedTick(deltaTime);
            }
        }
        #endregion
    }
}
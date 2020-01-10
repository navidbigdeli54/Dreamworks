/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System.Threading.Tasks;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public abstract class FParallelState : IParallelState
    {
        #region Fields
        private bool isActive;

        private readonly string name;

        private readonly List<IState> subStates = new List<IState>();

        private readonly List<ITransition> transactions = new List<ITransition>();
        #endregion

        #region Properties
        protected IHFSM HFSM { get; }

        protected IState Parent { get; private set; }
        #endregion

        #region Constructors
        public FParallelState(IHFSM hfsm)
        {
            this.HFSM = hfsm;
            this.name = this.GetType().Name;
        }
        #endregion

        #region IParallelState Implementation
        IReadOnlyList<IState> IParallelState.Substates => subStates;
        #endregion

        #region Methods
        protected virtual void OnEnter() { }

        protected virtual void OnExit() { }

        protected virtual Task PreInitializeAsync() => Task.CompletedTask;

        protected virtual Task InitializeAsync() => Task.CompletedTask;

        protected virtual Task BeginPlayAsync() => Task.CompletedTask;

        protected virtual Task UninitializeAsync() => Task.CompletedTask;

        protected virtual void Tick(float deltaTime) { }

        protected virtual void LateTick(float deltaTime) { }

        protected virtual void FixedTick(float deltaTime) { }

        protected void AddSubstate<T>(IState substate) where T : IState
        {
            FAssert.IsNotNull(subStates, "Substate can't be null");

            ((FParallelState)substate).Parent = this;
            subStates.Add(substate);
            HFSM.AddState<T>(substate);
        }

        protected void AddTransaction(FStringId trigger, IState target)
        {
            FAssert.IsTrue(trigger != null, "Trigger is invalid.");
            FAssert.IsNotNull(target, $"Target state can't be null.");

            transactions.Add(new FTransition(trigger, target));
        }

        protected void AddTransaction(FStringId trigger, IState target, ICondition condition)
        {
            FAssert.IsTrue(trigger != null, "Trigger is invalid.");
            FAssert.IsNotNull(target, $"Target state can't be null.");
            FAssert.IsNotNull(condition, "Condition can't be null");

            transactions.Add(new FTransition(trigger, target, condition));
        }

        protected void AddTransaction(FStringId trigger, IState target, ITransitionAction action)
        {
            FAssert.IsTrue(trigger != null, "Trigger is invalid.");
            FAssert.IsNotNull(target, $"Target state can't be null.");
            FAssert.IsNotNull(action, "Action can't be null");

            transactions.Add(new FTransition(trigger, target, action));
        }

        protected void AddTransaction(FStringId trigger, IState target, IEnumerable<ITransitionAction> actions)
        {
            FAssert.IsTrue(trigger != null, "Trigger is invalid.");
            FAssert.IsNotNull(target, $"Target state can't be null.");
            FAssert.IsNotNull(actions, "Actions can't be null");

            transactions.Add(new FTransition(trigger, target, actions));
        }

        protected void AddTransaction(FStringId trigger, IState target, ICondition condition, ITransitionAction action)
        {
            FAssert.IsTrue(trigger != null, "Trigger is invalid.");
            FAssert.IsNotNull(target, $"Target state can't be null.");
            FAssert.IsNotNull(condition, $"Condition can't be null.");
            FAssert.IsNotNull(action, "Action can't be null");

            transactions.Add(new FTransition(trigger, target, condition, action));
        }

        protected void AddTransaction(FStringId trigger, IState target, ICondition condition, IEnumerable<ITransitionAction> actions)
        {
            FAssert.IsTrue(trigger != null, "Trigger is invalid.");
            FAssert.IsNotNull(target, $"Target state can't be null.");
            FAssert.IsNotNull(condition, $"Condition can't be null.");
            FAssert.IsNotNull(actions, "Actions can't be null");

            transactions.Add(new FTransition(trigger, target, condition, actions));
        }
        #endregion

        #region IState Implementation
        IState IState.Parent => Parent;

        bool IState.IsActive => isActive;

        void IState.OnEnter()
        {
            isActive = true;

            OnEnter();
        }

        void IState.OnExit()
        {
            isActive = false;

            OnExit();
        }

        ITransition IState.CheckTransactions(FStringId trigger)
        {
            for (int i = 0; i < transactions.Count; i++)
            {
                ITransition transaction = transactions[i];

                if (transaction.Trigger == trigger && transaction.CheckCondition())
                {
                    return transaction;
                }
            }

            return null;
        }

        IReadOnlyList<IState> IState.GetAncestors()
        {
            List<IState> ancestors = new List<IState>();

            IState currentState = this;
            do
            {
                ancestors.Add(currentState);
                currentState = currentState.Parent;
            } while (currentState != null);

            return ancestors;
        }

        bool IState.IsAncestor(IState state)
        {
            FAssert.IsNotNull(state, "State parameter can't be null.");

            IState currentState = this;
            while (currentState.Parent != null)
            {
                if (currentState.Parent == state) return true;

                currentState = currentState.Parent;
            }

            return false;
        }
        #endregion

        #region INameable Implementation
        string INameable.Name => name;
        #endregion

        #region IPureTickable Implementation
        void IPureTickable.Tick(float deltaTime) => Tick(deltaTime);

        void IPureTickable.LateTick(float deltaTime) => LateTick(deltaTime);

        void IPureTickable.FixedTick(float deltaTime) => FixedTick(deltaTime);
        #endregion

        #region IPureInitializable Implementation
        Task IPureInitializable.PreInitializeAsync() => PreInitializeAsync();

        Task IPureInitializable.InitializeAsync() => InitializeAsync();

        Task IPureInitializable.BeginPlayAsync() => BeginPlayAsync();

        Task IPureInitializable.UninitializeAsync() => UninitializeAsync();
        #endregion
    }
}
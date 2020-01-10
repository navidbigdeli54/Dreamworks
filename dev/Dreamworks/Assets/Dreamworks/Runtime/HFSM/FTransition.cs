/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public sealed class FTransition : ITransition
    {
        #region Fields
        private readonly FStringId trigger;

        private readonly IState target;

        private readonly ICondition condition;

        private readonly List<ITransitionAction> actions = new List<ITransitionAction>();
        #endregion

        #region Constructor
        public FTransition(FStringId trigger, IState target)
        {
            this.target = target;
            this.trigger = trigger;
        }

        public FTransition(FStringId trigger, IState target, ICondition condition)
        {
            this.target = target;
            this.trigger = trigger;
            this.condition = condition;
        }

        public FTransition(FStringId trigger, IState target, ITransitionAction action)
        {
            this.target = target;
            this.trigger = trigger;
            this.actions.Add(action);
        }

        public FTransition(FStringId trigger, IState target, IEnumerable<ITransitionAction> actions)
        {
            this.target = target;
            this.trigger = trigger;
            this.actions.AddRange(actions);
        }

        public FTransition(FStringId trigger, IState target, ICondition condition, ITransitionAction action)
        {
            this.target = target;
            this.trigger = trigger;
            this.condition = condition;
            this.actions.Add(action);
        }

        public FTransition(FStringId trigger, IState target, ICondition condition, IEnumerable<ITransitionAction> actions)
        {
            this.target = target;
            this.trigger = trigger;
            this.condition = condition;
            this.actions.AddRange(actions);
        }
        #endregion

        #region ITransaction Implementation
        IState ITransition.Target => target;

        FStringId ITransition.Trigger => trigger;

        bool ITransition.CheckCondition() => condition == null ? true : condition.Check();

        void ITransition.PerformActions()
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Perform();
            }
        }
        #endregion
    }
}
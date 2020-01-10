/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using DreamMachineGameStudio.Dreamworks.Rule;

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public abstract class FCondition : ICondition
    {
        #region Fields
        private readonly FRule rule;
        #endregion

        #region Constructors
        public FCondition(FRule rule) => this.rule = rule;
        #endregion

        #region ICondition Implementation
        bool ICondition.Check() => rule.Evaluate();
        #endregion
    }
}
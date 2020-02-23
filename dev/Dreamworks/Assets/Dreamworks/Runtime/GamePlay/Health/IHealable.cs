/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;

namespace DreamMachineGameStudio.Dreamworks.GamePlay.Health
{
    public interface IHealable
    {
        #region Properties
        Action<IHeal> OnHeal { get; }
        #endregion

        #region Methods
        void Heal(IHeal heal);
        #endregion
    }
}
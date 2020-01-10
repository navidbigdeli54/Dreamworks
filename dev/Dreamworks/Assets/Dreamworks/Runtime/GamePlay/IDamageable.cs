/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;

namespace DreamMachineGameStudio.Dreamworks.GamePlay
{
    public interface IDamageable
    {
        #region Properties
        Action OnDeath { get; }

        Action<IDamage> OnTakeDamage { get; }
        #endregion

        #region Methods
        void TakeDamage(IDamage damage);
        #endregion
    }
}
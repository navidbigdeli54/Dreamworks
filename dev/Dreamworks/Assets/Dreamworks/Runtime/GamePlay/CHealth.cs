/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.GamePlay
{
    public class CHealth : CComponent, IDamageable, IHealable
    {
        #region Fields
        protected const int MIN_HEALTH = 0;

        protected const int MAX_HEALTH = 100;

        [SerializeField]
        protected int health = MAX_HEALTH;
        #endregion

        #region Properties
        public int Health => health;
        #endregion

        #region IHealable
        public Action<IHeal> OnHeal { get; }

        public void Heal(IHeal heal)
        {
            health = Mathf.Clamp(health += heal.Amount, MIN_HEALTH, MAX_HEALTH);

            OnHeal?.Invoke(heal);
        }
        #endregion

        #region IDamageable
        public Action OnDeath { get; }

        public Action<IDamage> OnTakeDamage { get; }

        public void TakeDamage(IDamage damage)
        {
            health = Mathf.Clamp(health - damage.Amount, MIN_HEALTH, MAX_HEALTH);

            OnTakeDamage?.Invoke(damage);

            if (health == MIN_HEALTH)
            {
                OnDeath?.Invoke();
            }
        }
        #endregion
    }
}
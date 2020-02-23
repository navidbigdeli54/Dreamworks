/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using System.Collections.Generic;

namespace DreamMachineGameStudio.Dreamworks.Rule
{
    public sealed class FRuleDB
    {
        #region Fields
        private readonly List<FRule> rules = new List<FRule>();
        #endregion

        #region Methods
        public void AddRule(FRule rule) => rules.Add(rule);

        public bool Evaluate()
        {
            for (int i = 0; i < rules.Count; i++)
            {
                if (rules[i].Evaluate())
                {
                    return true;
                }
            }

            return false;
        }

        public IResponse GetResponse()
        {
            List<FRule> acceptedRules = new List<FRule>(rules.Count);

            int maxCriteriaNumber = 0;

            for (int i = 0; i < rules.Count; i++)
            {
                FRule rule = rules[i];

                if (rule.Evaluate())
                {
                    if (rule.Criterias.Count >= maxCriteriaNumber)
                    {
                        if (rule.Criterias.Count > maxCriteriaNumber)
                        {
                            acceptedRules.Clear();

                            maxCriteriaNumber = rule.Criterias.Count;
                        }

                        acceptedRules.Add(rule);
                    }
                }
            }

            if (acceptedRules.Count == 0) return null;

            return acceptedRules[Random.Range(0, acceptedRules.Count)].Response;
        }
        #endregion
    }
}
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

        public FRespone GetResponse()
        {
            List<FRule> acceptedRules = new List<FRule>(rules.Count);

            int maxCriteriaNumber = 0;

            for (int i = 0; i < rules.Count; i++)
            {
                FRule rule = rules[i];

                if (rule.Evaluate())
                {
                    if (maxCriteriaNumber <= rule.Criterias.Count)
                    {
                        if (maxCriteriaNumber == rule.Criterias.Count)
                        {
                            acceptedRules.Add(rule);
                        }
                        else
                        {
                            maxCriteriaNumber = rule.Criterias.Count;

                            acceptedRules.Clear();
                            acceptedRules.Add(rule);
                        }
                    }
                }
            }

            if (acceptedRules.Count == 0) return null;

            if (acceptedRules.Count == 1) return acceptedRules[0].Response;

            return acceptedRules[Random.Range(0, acceptedRules.Count)].Response;
        }
        #endregion
    }
}
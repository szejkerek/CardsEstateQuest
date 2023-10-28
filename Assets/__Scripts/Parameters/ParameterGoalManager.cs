using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterGoalManager : Singleton<ParameterGoalManager> 
{
    [SerializeField] RectTransform goalsContainer;
    [SerializeField] ParameterGoal goalsPrefab;

    Dictionary<string, ParameterGoal> parameterGoals = new Dictionary<string, ParameterGoal>();

    private void Start()
    {
        SetupParameters();
    }

    void SetupParameters()
    {
        IDifficulty difficulty = GameManager.Instance.Difficulty;
        foreach(var paramRule in difficulty.CardParameters) 
        {
            ParameterGoal goal = Instantiate(goalsPrefab, goalsContainer);
            goal.Init(paramRule);
            parameterGoals.Add(paramRule.GetCategory(), goal);
        }
    }

    public void UpdateGlobalParameters(List<ParameterValue> cardValues, bool cardDestroyed = false)
    {
        foreach (var parameter in parameterGoals)
        {
            foreach(var paramValue in cardValues)
            {
                if(paramValue.GetCategory() == parameter.Key)
                {
                    parameter.Value.UpdateParameter(paramValue.Value, cardDestroyed);
                    break;
                }
            }
        }
    }
}

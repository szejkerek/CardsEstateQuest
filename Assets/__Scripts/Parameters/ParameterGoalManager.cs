using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterGoalManager : Singleton<ParameterGoalManager> 
{
    [SerializeField] RectTransform goalsContainer;
    [SerializeField] ParameterGoal goalsPrefab;

    Dictionary<string, ParameterGoal> m_parameterGoals;

    private void Start()
    {
        SetupParameters();
    }

    private void SetupParameters()
    {
        IDifficulty difficulty = GameManager.Instance.Difficulty;
        foreach(var paramRule in difficulty.CardParameters) 
        {
            ParameterGoal goal = Instantiate(goalsPrefab, goalsContainer);
            goal.SetUp(paramRule);
        }
    }

    void UpdateGoals()
    {
        foreach (var parameter in m_parameterGoals)
        {
            parameter.Value.UpdateParameter(1);
        }
    }
}

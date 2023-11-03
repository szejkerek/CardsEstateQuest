using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages parameter goals and their updates based on card values.
/// </summary>
public class ParameterGoalManager : MonoBehaviour
{
    [SerializeField] RectTransform goalsContainer;
    [SerializeField] ParameterGoal goalsPrefab;

    Dictionary<string, ParameterGoal> parameterGoals = new Dictionary<string, ParameterGoal>();

    private void Start()
    {
        SetupParameters();
    }

    /// <summary>
    /// Sets up parameter goals based on the current difficulty.
    /// </summary>
    void SetupParameters()
    {
        IDifficulty difficulty = GameManager.Instance.Difficulty;
        foreach (var paramRule in difficulty.CardParameters)
        {
            ParameterGoal goal = Instantiate(goalsPrefab, goalsContainer);
            goal.Init(paramRule);
            parameterGoals.Add(paramRule.GetCategory(), goal);
        }
    }

    /// <summary>
    /// Updates the global parameters based on card values.
    /// </summary>
    /// <param name="cardValues">The values from the card.</param>
    /// <param name="cardDestroyed">Indicates whether the card was destroyed.</param>
    public void UpdateGlobalParameters(List<ParameterValue> cardValues, bool cardDestroyed = false)
    {
        foreach (var parameter in parameterGoals)
        {
            foreach (var paramValue in cardValues)
            {
                if (paramValue.GetCategory() == parameter.Key)
                {
                    parameter.Value.UpdateParameter(paramValue.Value, cardDestroyed);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Checks if all parameter goals have been accomplished.
    /// </summary>
    /// <returns>True if all goals have been accomplished; otherwise, false.</returns>
    public bool DidWin()
    {
        bool win = true;
        foreach (var parameter in parameterGoals)
        {
            if (!parameter.Value.ConditionAcomplished())
                win = false;
        }
        return win;
    }
}

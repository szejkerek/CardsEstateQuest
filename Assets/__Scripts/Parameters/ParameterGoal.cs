using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages and displays information about a parameter goal.
/// </summary>
public class ParameterGoal : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image Icon;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI CurrentValue;
    [SerializeField] TextMeshProUGUI MinValue;
    [SerializeField] TextMeshProUGUI MaxValue;
    [SerializeField] TextMeshProUGUI ValueInfo;

    /// <summary>
    /// Gets the parameter rule associated with the goal.
    /// </summary>
    public ParameterRule ParameterRule => parameterRule;
    ParameterRule parameterRule;

    float value = 0;
    int cardsContributedToValue = 0;

    /// <summary>
    /// Initializes the parameter goal with the specified parameter rule.
    /// </summary>
    public void Init(ParameterRule parameterRule)
    {
        this.parameterRule = parameterRule;
        SetStaticParameterInfo(parameterRule);
        UpdateParameterGoalUI();
    }

    /// <summary>
    /// Updates the UI for the parameter goal.
    /// </summary>
    public void UpdateParameterGoalUI()
    {
        switch (parameterRule.GetValueType())
        {
            case ParameterTypeEnum.Decimal:
            case ParameterTypeEnum.Whole:
                CurrentValue.text = $"Val: {value}";
                break;
            case ParameterTypeEnum.Percentage:
                CurrentValue.text = $"Val: {value * 100}%";
                break;
        }
        ValueInfo.text = UpdateInfoText();
    }

    /// <summary>
    /// Updates the parameter value and UI based on a value to add and whether a card was destroyed.
    /// </summary>
    public void UpdateParameter(float valueToAdd, bool cardDestroyed)
    {
        float addValue = cardDestroyed ? -valueToAdd : valueToAdd;
        cardsContributedToValue += cardDestroyed ? -1 : 1;
        switch (parameterRule.GetValueType())
        {
            case ParameterTypeEnum.Whole:
                value += Mathf.RoundToInt(addValue);
                break;
            case ParameterTypeEnum.Decimal:
            case ParameterTypeEnum.Percentage:
                value = MovingAverage(addValue);
                break;
        }

        UpdateParameterGoalUI();
    }

    /// <summary>
    /// Checks if the condition of the parameter goal is accomplished.
    /// </summary>
    public bool ConditionAccomplished()
    {
        return (value >= parameterRule.MinValue && value <= parameterRule.MaxValue);
    }

    private void SetStaticParameterInfo(ParameterRule parameterRule)
    {
        if (parameterRule.TryGetIcon(out var icon))
        {
            Icon.sprite = icon;
            Name.gameObject.SetActive(false);
        }
        else
        {
            Icon.sprite = null;
            Icon.gameObject.SetActive(false);
            Name.text = $"Name: {parameterRule.GetCategory()}";
        }

        if (parameterRule.GetValueType() == ParameterTypeEnum.Percentage)
        {
            MinValue.text = $"Min: {parameterRule.MinValue * 100}%";
            MaxValue.text = $"Max: {parameterRule.MaxValue * 100}%";
        }
        else
        {
            MinValue.text = $"Min: {parameterRule.MinValue}";
            MaxValue.text = $"Max: {parameterRule.MaxValue}";
        }
    }

    private string UpdateInfoText()
    {
        if (value < parameterRule.MinValue)
        {
            return $"Missing {parameterRule.MinValue - value} to minimum!";
        }
        else if (value > parameterRule.MaxValue)
        {
            return $"Exceeded over {value - parameterRule.MaxValue} from maximum!";
        }
        return "DONE!";
    }

    private float MovingAverage(float newValue)
    {
        if (cardsContributedToValue == 0)
        {
            return 0;
        }

        return value + ((newValue - value) / cardsContributedToValue);
    }
}

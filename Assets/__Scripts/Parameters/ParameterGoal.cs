using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParameterGoal : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image Icon;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI CurrentValue;
    [SerializeField] TextMeshProUGUI MinValue;
    [SerializeField] TextMeshProUGUI MaxValue;
    [SerializeField] TextMeshProUGUI ValueInfo;

    public ParameterRule ParameterRule => parameterRule;
    ParameterRule parameterRule;

    float value = 0;

    int cardsContributedToValue = 0;

    public void Init(ParameterRule parameterRule)
    {
        this.parameterRule = parameterRule;
        SetStaticParameterInfo(parameterRule);
        UpdateParameterGoalUI();
    }

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
                value = MovingAvarage(addValue);
                break;
        }

        UpdateParameterGoalUI();
    }

    public bool ConditionAcomplished()
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

        if(parameterRule.GetValueType() == ParameterTypeEnum.Percentage)
        {
            MinValue.text = $"Min: {parameterRule.MinValue*100}%";
            MaxValue.text = $"Max: {parameterRule.MaxValue*100}%";
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
            return $"Missing {ParameterRule.MinValue - value} to minimum!";
        }
        else if (value > parameterRule.MaxValue)
        {
            return $"Exceeded over {value - ParameterRule.MaxValue } from maximum!";
        }
        return "DONE!";
    }

    private float MovingAvarage(float newValue)
    {
        if(cardsContributedToValue == 0)
        {
            return 0;
        }

        return value + ((newValue - value) / cardsContributedToValue);
    }
}

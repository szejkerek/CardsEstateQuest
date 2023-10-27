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

    public float Value => value;
    float value;

    public void UpdateParameter(float addValue)
    {
        value += addValue;
    }

    public void SetUp(ParameterRule parameterRule)
    {
        this.parameterRule = parameterRule;
        value = 0;

        if(parameterRule.TryGetIcon(out var icon))
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
        CurrentValue.text = $"CurrentValue: {0}";
        MinValue.text = $"Min Value: {parameterRule.MinValue}";
        MaxValue.text = $"Max Value: {parameterRule.MaxValue}";
        ValueInfo.text = $"Info: {UpdateInfoText()}";
    }

    private string UpdateInfoText()
    {
        return "no info gathered";
    }
}

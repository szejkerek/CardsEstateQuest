using System;
using System.Collections;
using System.Collections.Generic;
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

    private void SetUpUI(ParameterRule parameterRule)
    {
        if(parameterRule.TryGetIcon(out var icon))
        {
            Icon.sprite = icon;
            Name.text = string.Empty;
        }
        else
        {
            Icon.sprite = null;
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

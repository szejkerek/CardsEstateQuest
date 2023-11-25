using UnityEngine;

/// <summary>
/// Represents a parameter rule with a category, minimum value, and maximum value.
/// </summary>
[System.Serializable]
public class ParameterRule : Parameter
{
    /// <summary>
    /// Gets the minimum value for the parameter rule.
    /// </summary>
    public float MinValue => minValue;

    [SerializeField] private float minValue;

    /// <summary>
    /// Gets the maximum value for the parameter rule.
    /// </summary>
    public float MaxValue => maxValue;

    [SerializeField] private float maxValue;
}

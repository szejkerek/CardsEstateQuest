using UnityEngine;

/// <summary>
/// Represents a parameter value with a specified category.
/// </summary>
[System.Serializable]
public class ParameterValue : Parameter
{
    /// <summary>
    /// Initializes a parameter value with the specified category and a default value of 0.
    /// </summary>
    public ParameterValue(string category)
    {
        SetCategory(category);
        value = 0;
    }

    /// <summary>
    /// Gets the value of the parameter.
    /// </summary>
    public float Value => value;

    [SerializeField] private float value;
}

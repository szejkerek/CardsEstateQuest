using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ScriptableObject representing a difficulty level.
/// </summary>
[CreateAssetMenu(fileName = "DefaultDifficulty", menuName = "Difficulty", order = 1)]
public class DifficultySO : ScriptableObject, IDifficulty
{
    /// <summary>
    /// Gets the name of the difficulty level.
    /// </summary>
    [field: SerializeField]
    public string Name { private set; get; }

    /// <summary>
    /// Gets the icon associated with the difficulty level.
    /// </summary>
    [field: SerializeField]
    public Sprite Icon { private set; get; }

    /// <summary>
    /// Gets the list of parameter rules for the difficulty level.
    /// </summary>
    [field: SerializeField]
    public List<ParameterRule> CardParameters { private set; get; }

    /// <summary>
    /// Gets the number of bombs for the difficulty level.
    /// </summary>
    [field: SerializeField]
    public int NumberOfBombs { private set; get; }
}

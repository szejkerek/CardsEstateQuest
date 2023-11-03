using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interface representing a difficulty level.
/// </summary>
public interface IDifficulty
{
    /// <summary>
    /// Gets the name of the difficulty level.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the icon associated with the difficulty level.
    /// </summary>
    Sprite Icon { get; }

    /// <summary>
    /// Gets the list of parameter rules for the difficulty level.
    /// </summary>
    List<ParameterRule> CardParameters { get; }

    /// <summary>
    /// Gets the number of bombs for the difficulty level.
    /// </summary>
    int NumberOfBombs { get; }
}

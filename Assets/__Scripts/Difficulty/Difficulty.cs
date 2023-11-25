using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A class representing a difficulty level.
/// </summary>
public class Difficulty : IDifficulty
{
    /// <summary>
    /// Gets the name of the difficulty level.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Gets the icon associated with the difficulty level.
    /// </summary>
    public Sprite Icon => _icon;

    /// <summary>
    /// Gets the list of parameter rules for the difficulty level.
    /// </summary>
    public List<ParameterRule> CardParameters => _cardParameters;

    /// <summary>
    /// Gets the number of bombs for the difficulty level.
    /// </summary>
    public int NumberOfBombs => _numberOfBombs;

    private string _name;
    private Sprite _icon;
    private List<ParameterRule> _cardParameters;
    private int _numberOfBombs;

    /// <summary>
    /// Initializes a new instance of the Difficulty class with the specified parameters.
    /// </summary>
    public Difficulty(string name, Sprite icon, List<ParameterRule> cardParameters, int numberOfBombs)
    {
        _name = name;
        _icon = icon;
        _cardParameters = cardParameters;
        _numberOfBombs = numberOfBombs;
    }

    /// <summary>
    /// Initializes a new instance of the Difficulty class based on an existing IDifficulty.
    /// </summary>
    public Difficulty(IDifficulty difficultySO)
    {
        _name = difficultySO.Name;
        _icon = difficultySO.Icon;
        _cardParameters = difficultySO.CardParameters;
        _numberOfBombs = difficultySO.NumberOfBombs;
    }

    /// <summary>
    /// Checks if the difficulty level is valid and logs warnings if not.
    /// </summary>
    public bool IsValid()
    {
        bool lessThanOneParameter = (_cardParameters.Count < 1);

        bool hasDuplicateCategories = _cardParameters.GroupBy(item => item.GetCategory())
            .Any(group => group.Count() > 1);

        bool isValid = (!lessThanOneParameter && !hasDuplicateCategories);

        if (lessThanOneParameter)
        {
            Debug.LogWarning($"The {Name} has less than one parameter.");
        }

        if (hasDuplicateCategories)
        {
            Debug.LogWarning($"The {Name} has duplicate categories.");
        }

        if (!isValid)
        {
            Debug.LogWarning($"The {Name} is not valid.");
        }

        return isValid;
    }
}

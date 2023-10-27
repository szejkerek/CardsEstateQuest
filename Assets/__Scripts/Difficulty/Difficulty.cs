using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Difficulty : IDifficulty
{
    public string Name => _name;
    public Sprite Icon => _icon;
    public List<ParameterRule> CardParameters => _cardParameters;
    public int NumberOfBombs => _numberOfBombs;

    private string _name;
    private Sprite _icon;
    private List<ParameterRule> _cardParameters;
    private int _numberOfBombs;
   
    public Difficulty(string name, Sprite icon, List<ParameterRule> cardParameters, int numberOfBombs)
    {
        _name = name;
        _icon = icon;
        _cardParameters = cardParameters;
        _numberOfBombs = numberOfBombs;
    }

    public Difficulty(IDifficulty difficultySO)
    {
        _name = difficultySO.Name;
        _icon = difficultySO.Icon;
        _cardParameters = difficultySO.CardParameters;
        _numberOfBombs = difficultySO.NumberOfBombs;
    }

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

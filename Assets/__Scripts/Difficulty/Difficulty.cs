using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : IDifficulty
{
    public string Name => _name;
    public Sprite Icon => _icon;
    public List<ParameterRule> CardParameters => _cardParameters;
    public int NumberOfParameters => _numberOfParameters;
    public int NumberOfBombs => _numberOfBombs;

    private string _name;
    private Sprite _icon;
    private List<ParameterRule> _cardParameters;
    private int _numberOfParameters;
    private int _numberOfBombs;
   
    public Difficulty(string name, Sprite icon, List<ParameterRule> cardParameters, int numberOfParameters, int numberOfBombs)
    {
        _name = name;
        _icon = icon;
        _cardParameters = cardParameters;
        _numberOfParameters = numberOfParameters;
        _numberOfBombs = numberOfBombs;
    }
}

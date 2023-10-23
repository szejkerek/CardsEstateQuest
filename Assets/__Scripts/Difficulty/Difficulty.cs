using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : IDifficulty
{
    public string Name => throw new System.NotImplementedException();
    public Sprite Icon => throw new System.NotImplementedException();
    public CardParameter CardParameter => throw new System.NotImplementedException();
    public int NumberOfParameters => throw new System.NotImplementedException();
    public int NumberOfBombs => throw new System.NotImplementedException();

    private string _name;
    private Sprite _icon;
    private CardParameter _cardParameter;
    private int _numberOfParameters;
    private int _numberOfBombs;
   
    public Difficulty(string name, Sprite icon, CardParameter cardParameter, int numberOfParameters, int numberOfBombs)
    {
        _name = name;
        _icon = icon;
        _cardParameter = cardParameter;
        _numberOfParameters = numberOfParameters;
        _numberOfBombs = numberOfBombs;
    }
}

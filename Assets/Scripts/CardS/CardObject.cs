using System.Collections.Generic;
using UnityEngine;

public class CardObject
{
    public CardFigure Fiugure => fiugure;
    public CardColor Color => color;
    public Sprite Pictogram => pictogram;
    public List<CardParameter> Parameters => parameters;
    public GameObject Model => model;
    
    private CardFigure fiugure;
    private CardColor color;
    private Sprite pictogram;
    private List<CardParameter> parameters;
    private GameObject model;

    public CardObject(CardSO cardSO)
    {
        fiugure = cardSO.Fiugure; 
        color = cardSO.Color;
        pictogram = cardSO.Pictogram;
        parameters = cardSO.Parameters;
        model = cardSO.Model;
    }

    public CardObject(CardFigure _fiugure, CardColor _color, Sprite _sprite, List<CardParameter> _cardParameters, GameObject _model)
    {
        fiugure = _fiugure;
        color = _color;
        pictogram = _sprite;
        parameters = _cardParameters;
        model = _model;
    }
}

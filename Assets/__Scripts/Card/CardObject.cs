﻿using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardObject : ICard
{
    public CardFigure Figure => figure;
    public CardColor Color => color;
    public Sprite Pictogram => pictogram;
    public List<ParameterValue> Parameters => parameters;
    public GameObject Model => model;

    private CardFigure figure;
    private CardColor color;
    private Sprite pictogram;
    private List<ParameterValue> parameters;
    private GameObject model;

    public CardObject(CardFigure _fiugure,
                      CardColor _color,
                      Sprite _sprite,
                      List<ParameterValue> _cardParameters,
                      GameObject _model)
    {
        figure = _fiugure;
        color = _color;
        pictogram = _sprite;
        parameters = _cardParameters;
        model = _model;
    }

    public CardObject(ICard card)
    {
        figure = card.Figure;
        color = card.Color;
        pictogram = card.Pictogram;
        parameters = card.Parameters;
        model = card.Model;
    }

    public void OnCardPlaced()
    {
        ParameterGoalManager.Instance.UpdateGlobalParameters(Parameters);
        Debug.Log("Placed");
    }
    public void OnCardDestroyed()
    {
        Debug.Log("Destroyed");
    }
}

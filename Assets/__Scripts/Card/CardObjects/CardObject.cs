using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardObject: ICard
{
    public CardFigure Figure => figure;
    public CardColor Color => color;
    public Sprite Pictogram => pictogram;
    public List<CardParameter> Parameters => parameters;
    public GameObject Model => model;

    private CardFigure figure;
    private CardColor color;
    private Sprite pictogram;
    private List<CardParameter> parameters;
    private GameObject model;

    public CardObject(CardFigure _fiugure, 
                      CardColor _color,
                      Sprite _sprite,
                      List<CardParameter> _cardParameters,
                      GameObject _model)
    {
        figure = _fiugure;
        color = _color;
        pictogram = _sprite;
        parameters = _cardParameters;
        model = _model;
    }
}

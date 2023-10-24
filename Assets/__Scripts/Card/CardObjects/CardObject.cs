using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardObject: ICard
{
    public CardFigure Figure => figure;
    public CardColor Color => color;
    public Sprite Pictogram => pictogram;
    public List<CardParameterSO> Parameters => parameters;
    public GameObject Model => model;

    private CardFigure figure;
    private CardColor color;
    private Sprite pictogram;
    private List<CardParameterSO> parameters;
    private GameObject model;

    public CardObject(CardFigure _fiugure, 
                      CardColor _color,
                      Sprite _sprite,
                      List<CardParameterSO> _cardParameters,
                      GameObject _model)
    {
        figure = _fiugure;
        color = _color;
        pictogram = _sprite;
        parameters = _cardParameters;
        model = _model;
    }
}

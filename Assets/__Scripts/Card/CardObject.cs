using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CardObject : ICard
{
    public CardFigure Figure => figure;
    public CardColor Color => color;
    public Sprite Pictogram => pictogram;
    public List<ParameterValue> Parameters => parameters;
    public GameObject Model => model;
    public int Width => width;
    public int Length => length;
    public Sprite Image => image;

    private CardFigure figure;
    private CardColor color;
    private Sprite pictogram;
    private List<ParameterValue> parameters;
    private GameObject model;
    private int width;
    private int length;
    private Sprite image;

    public CardObject(CardFigure _figure,
                      CardColor _color,
                      Sprite _sprite,
                      List<ParameterValue> _cardParameters,
                      GameObject _model,
                      int _width,
                      int _length,
                      Sprite _image)
    {
        figure = _figure;
        color = _color;
        pictogram = _sprite;
        parameters = _cardParameters;
        model = _model;
        width = _width;
        length = _length;
        image = _image;
    }

    public CardObject(ICard card)
    {
        figure = card.Figure;
        color = card.Color;
        pictogram = card.Pictogram;
        parameters = card.Parameters;
        model = card.Model;
        width = card.Width;
        length = card.Length;
        image = card.Image;
    }

}

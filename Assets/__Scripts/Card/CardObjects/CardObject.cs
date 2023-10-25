using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a class for a card object with specific attributes.
/// </summary>
[System.Serializable]
public class CardObject : ICard
{
    /// <summary>
    /// Gets the figure of the card.
    /// </summary>
    public CardFigure Figure => figure;

    /// <summary>
    /// Gets the color or suit of the card.
    /// </summary>
    public CardColor Color => color;

    /// <summary>
    /// Gets the pictogram (image) associated with the card.
    /// </summary>
    public Sprite Pictogram => pictogram;

    /// <summary>
    /// Gets a list of parameters associated with the card.
    /// </summary>
    public List<CardParameter> Parameters => parameters;

    /// <summary>
    /// Gets the 3D model (GameObject) of the card.
    /// </summary>
    public GameObject Model => model;

    private CardFigure figure;
    private CardColor color;
    private Sprite pictogram;
    private List<CardParameter> parameters;
    private GameObject model;

    /// <summary>
    /// Initializes a new instance of the CardObject class with the specified attributes.
    /// </summary>
    public CardObject(CardFigure _figure,
                      CardColor _color,
                      Sprite _sprite,
                      List<CardParameter> _cardParameters,
                      GameObject _model)
    {
        figure = _figure;
        color = _color;
        pictogram = _sprite;
        parameters = _cardParameters;
        model = _model;
    }
}

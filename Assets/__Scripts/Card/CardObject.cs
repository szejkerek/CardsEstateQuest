using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A class representing a card object.
/// </summary>
[System.Serializable]
public class CardObject : ICard
{
    /// <summary>
    /// Gets the figure of the card (e.g., Ace, King, Queen).
    /// </summary>
    public CardFigure Figure => figure;

    /// <summary>
    /// Gets the color of the card (e.g., Hearts, Diamonds, Clubs, Spades).
    /// </summary>
    public CardColor Color => color;

    /// <summary>
    /// Gets the pictogram or image associated with the card.
    /// </summary>
    public Sprite Pictogram => pictogram;

    /// <summary>
    /// Gets a list of parameters or values associated with the card.
    /// </summary>
    public List<ParameterValue> Parameters => parameters;

    /// <summary>
    /// Gets the 3D model representation of the card in the game.
    /// </summary>
    public GameObject Model => model;

    private CardFigure figure;
    private CardColor color;
    private Sprite pictogram;
    private List<ParameterValue> parameters;
    private GameObject model;

    /// <summary>
    /// Initializes a new instance of the CardObject class with the specified parameters.
    /// </summary>
    public CardObject(CardFigure _figure, CardColor _color, Sprite _sprite, List<ParameterValue> _cardParameters, GameObject _model)
    {
        figure = _figure;
        color = _color;
        pictogram = _sprite;
        parameters = _cardParameters;
        model = _model;
    }

    /// <summary>
    /// Initializes a new instance of the CardObject class based on an existing ICard.
    /// </summary>
    public CardObject(ICard card)
    {
        figure = card.Figure;
        color = card.Color;
        pictogram = card.Pictogram;
        parameters = card.Parameters;
        model = card.Model;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This interface represents a card in a card game.
/// </summary>
public interface ICard
{
    /// <summary>
    /// Gets the figure of the card (e.g., Ace, King, Queen).
    /// </summary>
    CardFigure Figure { get; }

    /// <summary>
    /// Gets the color of the card (e.g., Hearts, Diamonds, Clubs, Spades).
    /// </summary>
    CardColor Color { get; }

    /// <summary>
    /// Gets the pictogram or image associated with the card.
    /// </summary>
    Sprite Pictogram { get; }

    /// <summary>
    /// Gets a list of parameters or values associated with the card.
    /// </summary>
    List<ParameterValue> Parameters { get; }

    /// <summary>
    /// Gets the 3D model representation of the card in the game.
    /// </summary>
    GameObject Model { get; }
}

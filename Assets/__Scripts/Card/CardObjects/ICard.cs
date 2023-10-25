using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an interface for a generic card.
/// </summary>
public interface ICard
{
    /// <summary>
    /// Gets the figure of the card.
    /// </summary>
    CardFigure Figure { get; }

    /// <summary>
    /// Gets the color or suit of the card.
    /// </summary>
    CardColor Color { get; }

    /// <summary>
    /// Gets the pictogram (image) associated with the card.
    /// </summary>
    Sprite Pictogram { get; }

    /// <summary>
    /// Gets a list of parameters associated with the card.
    /// </summary>
    List<CardParameter> Parameters { get; }

    /// <summary>
    /// Gets the 3D model (GameObject) of the card.
    /// </summary>
    GameObject Model { get; }
}

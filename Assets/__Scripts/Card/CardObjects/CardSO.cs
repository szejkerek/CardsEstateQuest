using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a ScriptableObject for a card with specific attributes.
/// </summary>
[CreateAssetMenu(fileName = "CardDefault", menuName = "Card/CardObject")]
public class CardSO : ScriptableObject, ICard
{
    /// <summary>
    /// Gets or sets the figure of the card.
    /// </summary>
    [field: SerializeField]
    public CardFigure Figure { private set; get; }

    /// <summary>
    /// Gets or sets the color or suit of the card.
    /// </summary>
    [field: SerializeField]
    public CardColor Color { private set; get; }

    /// <summary>
    /// Gets or sets the pictogram (image) associated with the card.
    /// </summary>
    [field: SerializeField]
    public Sprite Pictogram { private set; get; }

    /// <summary>
    /// Gets or sets a list of parameters associated with the card.
    /// </summary>
    [field: SerializeField]
    public List<CardParameter> Parameters { private set; get; }

    /// <summary>
    /// Gets or sets the 3D model (GameObject) of the card.
    /// </summary>
    [field: SerializeField]
    public GameObject Model { private set; get; }
}

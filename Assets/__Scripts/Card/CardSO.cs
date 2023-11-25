using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A ScriptableObject representing a card in a card game.
/// </summary>
[CreateAssetMenu(fileName = "CardDefault", menuName = "Card/CardObject")]
public class CardSO : ScriptableObject, ICard
{
    /// <summary>
    /// Gets the figure of the card (e.g., Ace, King, Queen).
    /// </summary>
    [field: SerializeField] public CardFigure Figure { private set; get; }

    /// <summary>
    /// Gets the color of the card (e.g., Hearts, Diamonds, Clubs, Spades).
    /// </summary>
    [field: SerializeField] public CardColor Color { private set; get; }

    /// <summary>
    /// Gets the pictogram or image associated with the card.
    /// </summary>
    [field: SerializeField] public Sprite Pictogram { private set; get; }

    /// <summary>
    /// Gets a list of parameters or values associated with the card.
    /// </summary>
    [field: SerializeField] public List<ParameterValue> Parameters { private set; get; }

    /// <summary>
    /// Gets the 3D model representation of the card in the game.
    /// </summary>
    [field: SerializeField] public GameObject Model { private set; get; }
}

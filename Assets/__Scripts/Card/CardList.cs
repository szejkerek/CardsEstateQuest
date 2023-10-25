using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Represents a class for managing a list of card objects.
/// </summary>
public class CardList
{
    /// <summary>
    /// Gets the list of card objects.
    /// </summary>
    public List<ICard> CardsObjects => cardObjects;

    private List<ICard> cardObjects;

    /// <summary>
    /// Initializes a new instance of the CardList class and creates an empty list of card objects.
    /// </summary>
    public CardList()
    {
        cardObjects = new List<ICard>();
    }

    /// <summary>
    /// Loads a list of card objects from a specified path using the provided card loader.
    /// </summary>
    /// <param name="loader">The card loader to use for loading the cards.</param>
    /// <param name="path">The path from which to load the cards.</param>
    public void Create(ICardLoader loader, string path)
    {
        cardObjects = loader.LoadCards(path);
    }

    /// <summary>
    /// Retrieves a card by its ID.
    /// </summary>
    /// <param name="cardId">The ID of the card to retrieve.</param>
    /// <returns>The card with the specified ID, or null if not found.</returns>
    public ICard GetCard(int cardId)
    {
        if (cardObjects == null || cardId >= cardObjects.Count)
        {
            Debug.LogError($"Couldn't get card with ID - {cardId}");
            return null;
        }
        return cardObjects.ElementAt(cardId);
    }

    /// <summary>
    /// Retrieves a random card from the list of card objects.
    /// </summary>
    /// <returns>A random card from the list.</returns>
    public ICard GetRandomCard()
    {
        int index = Random.Range(0, cardObjects.Count);
        return cardObjects[index];
    }

    /// <summary>
    /// Updates a card in the list with a new card object.
    /// </summary>
    /// <param name="newCard">The new card object to replace the existing card.</param>
    /// <param name="cardId">The ID of the card to update.</param>
    public void UpdateCard(ICard newCard, int cardId)
    {
        if (cardObjects == null || cardId >= cardObjects.Count)
        {
            Debug.LogError($"Couldn't update card with ID - {cardId}");
            return;
        }

        cardObjects[cardId] = newCard;
    }

    /// <summary>
    /// Removes a card from the list by its ID.
    /// </summary>
    /// <param name="cardId">The ID of the card to remove.</param>
    public void RemoveCard(int cardId)
    {
        if (cardObjects == null || cardId >= cardObjects.Count)
        {
            Debug.LogError($"Couldn't remove card with ID - {cardId}");
            return;
        }

        cardObjects.RemoveAt(cardId);
    }
}

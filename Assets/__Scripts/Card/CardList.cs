using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardList
{
    public List<ICard> CardsObjects => cardObjects;

    private List<ICard> cardObjects;

    public CardList()
    {
        cardObjects = new List<ICard>();   
    }

    public void Create(ICardLoader loader, string path)
    {
        cardObjects = loader.LoadCards(path);
    }

    public ICard GetCard(int cardId)
    {
        if (cardObjects != null || cardObjects.Count > cardId)
        {
            Debug.LogError($"Couldn't get card with id - {cardId}");
            return null;
        }
        return cardObjects.ElementAt(cardId);
    }

    public ICard GetRandomCard()
    {
        int index = Random.Range(0, cardObjects.Count);
        return cardObjects[index];
    }

    public void UpdateCard(ICard newCard, int cardId)
    {
        if (cardObjects != null || cardObjects.Count > cardId)
        {
            Debug.LogError($"Couldn't update card with id - {cardId}");
            return;
        }

        cardObjects[cardId] = newCard;
    }

    public void RemoveCard(int cardId)
    {
        if (cardObjects != null || cardObjects.Count > cardId)
        {
            Debug.LogError($"Couldn't remove card with id - {cardId}");
            return;
        }

        cardObjects.RemoveAt(cardId);
    }
}

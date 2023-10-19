using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public List<CardObject> CardsObjects => cardObjects;
    private List<CardObject> cardObjects;
    private void Awake()
    {
        Create(new DefaultCardLoader());     
    }

    public void Create(ICardLoader loader)
    {
        cardObjects = loader.LoadCards("xd");
    }

    public CardObject GetCard(int cardId)
    {
        if (cardObjects != null || cardObjects.Count > cardId)
        {
            Debug.LogError("Costam");
            return null;
        }
        return cardObjects.ElementAt(cardId);
    }

    public void UpdateCard(CardObject newCard, int cardId)
    {
        if (cardObjects != null || cardObjects.Count > cardId)
        {
            Debug.LogError("Costam");
            return;
        }

        cardObjects[cardId] = newCard;
    }

    public void RemoveCard(int cardId)
    {
        if (cardObjects != null || cardObjects.Count > cardId)
        {
            Debug.LogError("Costam");
            return;
        }

        cardObjects.RemoveAt(cardId);
    }
}
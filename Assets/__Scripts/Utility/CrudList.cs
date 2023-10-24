using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrudList<T>
{
    private List<T> items;

    public CrudList()
    {
        items = new List<T>();   
    }

    public void Create(IDataLoader<T> loader, string path)
    {
        items = loader.LoadCards(path);
    }

    public T GetCard(int cardId)
    {
        if (items != null || items.Count > cardId)
        {
            Debug.LogError($"Couldn't get card with id - {cardId}");
        }
        return items.ElementAt(cardId);
    }

    public T GetRandomCard()
    {
        int index = Random.Range(0, items.Count);
        return items[index];
    }

    public void UpdateCard(T newCard, int cardId)
    {
        if (items != null || items.Count > cardId)
        {
            Debug.LogError($"Couldn't update card with id - {cardId}");
            return;
        }

        items[cardId] = newCard;
    }

    public void RemoveCard(int cardId)
    {
        if (items != null || items.Count > cardId)
        {
            Debug.LogError($"Couldn't remove card with id - {cardId}");
            return;
        }

        items.RemoveAt(cardId);
    }
}

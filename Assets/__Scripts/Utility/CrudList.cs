using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrudList<T>
{
    private List<T> items;
    public int Count => items.Count;

    public CrudList()
    {
        items = new List<T>();   
    }

    public void LoadList(IDataLoader<T> loader, string path)
    {
        items = loader.LoadCards(path);
    }

    public T GetItem(int itemID)
    {
        if (IsInListRange(itemID))
        {
            Debug.LogError($"Couldn't get item with id - {itemID}");
            return default;
        }
        return items.ElementAt(itemID);
    }

    public T GetRandomItem()
    {
        int index = Random.Range(0, items.Count);
        return items[index];
    }

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void UpdateItem(T newItem, int cardId)
    {
        if (items != null || items.Count > cardId)
        {
            Debug.LogError($"Couldn't update item with id - {cardId}");
            return;
        }

        items[cardId] = newItem;
    }

    public void RemoveItem(int itemId)
    {
        if (items != null || items.Count > itemId)
        {
            Debug.LogError($"Couldn't remove item with id - {itemId}");
            return;
        }

        items.RemoveAt(itemId);
    }

    private bool IsInListRange(int itemId)
    {
        return itemId > items.Count || itemId < 0;
    }
}

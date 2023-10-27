using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CrudList<T> : IEnumerable<T>
{
    private List<T> items;
    public int Count => items.Count;

    DefaultLoader<T> loader = new DefaultLoader<T>();
    public CrudList()
    {
        items = new List<T>();
    }

    public void LoadList(string path)
    {
        items = loader.Load(path);
    }

    public void LoadList(AssetLabelReference label)
    {
        items = loader.Load(label);
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
        int index = UnityEngine.Random.Range(0, items.Count);
        return items[index];
    }

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void UpdateItem(T newItem, int cardId)
    {
        if (IsInListRange(cardId))
        {
            Debug.LogError($"Couldn't update item with id - {cardId}");
            return;
        }

        items[cardId] = newItem;
    }

    public void RemoveItem(int itemId)
    {
        if (IsInListRange(itemId))
        {
            Debug.LogError($"Couldn't remove item with id - {itemId}");
            return;
        }

        items.RemoveAt(itemId);
    }

    public void Remove(T item)
    {
        int index = items.IndexOf(item);
        if (index != -1)
        {
            items.RemoveAt(index);
        }
        else
        {
            Debug.LogError("Item not found in the list.");
        }

    }

    private bool IsInListRange(int itemId)
    {
        return itemId < 0 || itemId >= items.Count;
    }

    // Implement IEnumerable<T> to enable foreach
    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

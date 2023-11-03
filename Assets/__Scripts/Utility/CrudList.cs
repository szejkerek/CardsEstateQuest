using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// Represents a generic list with basic CRUD operations.
/// </summary>
public class CrudList<T> : IEnumerable<T>
{
    private List<T> items;

    /// <summary>
    /// Gets the count of items in the list.
    /// </summary>
    public int Count => items.Count;

    DefaultLoader<T> loader = new DefaultLoader<T>();

    /// <summary>
    /// Initializes a new instance of the CrudList.
    /// </summary>
    public CrudList()
    {
        items = new List<T>();
    }

    /// <summary>
    /// Loads a list from a given path.
    /// </summary>
    /// <param name="path">The path to load the list from.</param>
    public void LoadList(string path)
    {
        items = loader.Load(path);
    }

    /// <summary>
    /// Loads a list from a given label reference.
    /// </summary>
    /// <param name="label">The label reference to load the list from.</param>
    public void LoadList(AssetLabelReference label)
    {
        items = loader.Load(label);
    }

    /// <summary>
    /// Gets an item from the list by its index.
    /// </summary>
    /// <param name="itemID">The index of the item to retrieve.</param>
    /// <returns>The item at the specified index or a default value if not found.</returns>
    public T GetItem(int itemID)
    {
        if (IsInListRange(itemID))
        {
            Debug.LogError($"Couldn't get item with id - {itemID}");
            return default;
        }
        return items.ElementAt(itemID);
    }

    /// <summary>
    /// Gets a random item from the list.
    /// </summary>
    /// <returns>A randomly selected item from the list.</returns>
    public T GetRandomItem()
    {
        int index = UnityEngine.Random.Range(0, items.Count);
        return items[index];
    }

    /// <summary>
    /// Adds an item to the list.
    /// </summary>
    /// <param name="item">The item to add to the list.</param>
    public void AddItem(T item)
    {
        items.Add(item);
    }

    /// <summary>
    /// Updates an item in the list at the specified index.
    /// </summary>
    /// <param name="newItem">The new item to replace the existing one.</param>
    /// <param name="itemID">The index of the item to update.</param>
    public void UpdateItem(T newItem, int itemID)
    {
        if (IsInListRange(itemID))
        {
            Debug.LogError($"Couldn't update item with id - {itemID}");
            return;
        }

        items[itemID] = newItem;
    }

    /// <summary>
    /// Removes an item from the list by its index.
    /// </summary>
    /// <param name="itemId">The index of the item to remove.</param>
    public void RemoveItem(int itemId)
    {
        if (IsInListRange(itemId))
        {
            Debug.LogError($"Couldn't remove item with id - {itemId}");
            return;
        }

        items.RemoveAt(itemId);
    }

    /// <summary>
    /// Removes an item from the list.
    /// </summary>
    /// <param name="item">The item to remove from the list.</param>
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

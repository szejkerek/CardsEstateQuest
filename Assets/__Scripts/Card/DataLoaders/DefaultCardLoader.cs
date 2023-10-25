using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Represents a class for loading a list of cards from the Unity Resources folder.
/// </summary>
public class DefaultCardLoader : ICardLoader
{
    /// <summary>
    /// Loads a list of cards from the specified path within the Resources folder.
    /// </summary>
    /// <param name="path">The path from which to load the cards within the Resources folder.</param>
    /// <returns>A list of cards loaded from the specified path.</returns>
    public List<ICard> LoadCards(string path)
    {
        System.Object[] cards = Resources.LoadAll(path, typeof(ICard));
        return cards.OfType<ICard>().ToList();
    }
}

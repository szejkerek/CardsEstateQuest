using System.Collections.Generic;

/// <summary>
/// Represents an interface for loading a list of cards.
/// </summary>
public interface ICardLoader
{
    /// <summary>
    /// Loads a list of cards from the specified path.
    /// </summary>
    /// <param name="path">The path from which to load the cards.</param>
    /// <returns>A list of cards loaded from the path.</returns>
    List<ICard> LoadCards(string path);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A singleton class that manages various aspects of the game.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// Gets the list of cards managed by the game manager.
    /// </summary>
    public CardList CardList => cardList;
    private CardList cardList = new CardList();

    /// <summary>
    /// Gets the grid manager used by the game manager.
    /// </summary>
    public GridManager GridManager => gridManager;
    private GridManager gridManager;

    private void Start()
    {
        // Load a list of default cards from the "DefaultCards" path using a DefaultCardLoader.
        cardList.Create(new DefaultCardLoader(), "DefaultCards");

        // Get the GridManager component attached to this game object.
        gridManager = GetComponent<GridManager>();
    }
}

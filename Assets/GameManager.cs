using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{
    public CardList CardList => cardList;
    CardList cardList = new CardList();    
    public GridManager GridManager => gridManager;
    GridManager gridManager;

    private void Start()
    {
        cardList.Create(new DefaultCardLoader(), "DefaultCards"); 
        gridManager = GetComponent<GridManager>();    
    }
}

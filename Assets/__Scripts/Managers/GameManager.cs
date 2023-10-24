using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{
    public CrudList<ICard> CardList => cardList;
    CrudList<ICard> cardList = new CrudList<ICard>();    
    public GridManager GridManager => gridManager;
    GridManager gridManager;

    private void Start()
    {
        cardList.LoadList(new DefaultLoader<ICard>(), "DefaultCards"); 
        gridManager = GetComponent<GridManager>();    
    }
}

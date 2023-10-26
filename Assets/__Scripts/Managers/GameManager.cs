using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameManager : Singleton<GameManager> 
{
    public CrudList<ICard> CardList => cardList;
    CrudList<ICard> cardList = new CrudList<ICard>();    
    public GridManager GridManager => gridManager;
    GridManager gridManager;

    [SerializeField] AssetLabelReference defaultCardsLabel;

    private void Start()
    {
        cardList.LoadList(defaultCardsLabel); 
        gridManager = GetComponent<GridManager>();    
    }
}

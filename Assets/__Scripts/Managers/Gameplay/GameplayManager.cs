using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameplayManager : Singleton<GameplayManager> 
{
    [SerializeField] AssetLabelReference defaultCardsLabel;
    public CardObject SelectedCard => selectedCard;
    CardObject selectedCard;

    public HudManager HudManager => hudManager;
    HudManager hudManager;

    public CardHolder CardHolder => cardHolder;
    CardHolder cardHolder;

    public ParameterGoalManager ParameterGoalManager => parameterGoalManager;
    ParameterGoalManager parameterGoalManager;

    EndMenuManager endMenu;  

    protected override void Awake()
    {
        base.Awake();
   
        endMenu = GetComponent<EndMenuManager>(); 
    }

    private void Start()
    {
        hudManager = GetComponent<HudManager>();
        parameterGoalManager = GetComponent<ParameterGoalManager>();
        cardHolder = GetComponent<CardHolder>();
    }

    public void ShowEndMenu()
    {
        endMenu.Show(parameterGoalManager.DidWin());
    }

    public void SetSelectedCard(CardObject card)
    {
        selectedCard = card;
        Debug.Log(selectedCard.Model.name + " card selected");
    }

    public void DeselectCard()
    {
        cardHolder.RemoveCard(selectedCard);
        selectedCard = null;
        
    }

}

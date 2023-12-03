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

    public ParameterGoalManager ParameterGoalManager => parameterGoalManager;
    ParameterGoalManager parameterGoalManager;

    EndMenuManager endMenu;
    List<ICard> cardList = new List<ICard>();    

    protected override void Awake()
    {
        base.Awake();
        cardList = DefaultLoader<ICard>.Load(defaultCardsLabel);
        endMenu = GetComponent<EndMenuManager>(); 
    }

    private void Start()
    {
        hudManager = GetComponent<HudManager>();
        parameterGoalManager = GetComponent<ParameterGoalManager>();
    }

    public void ShowEndMenu()
    {
        endMenu.Show(parameterGoalManager.DidWin());
    }

    public void SelectCard()
    {
        selectedCard = new CardObject(cardList.SelectRandomElement());
        Debug.Log(selectedCard.Model.name + " card selected");
    }

    public void DeselectCard()
    {
        selectedCard = null;
    }

}

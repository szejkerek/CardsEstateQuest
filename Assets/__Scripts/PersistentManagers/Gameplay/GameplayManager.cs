using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameplayManager : Singleton<GameplayManager> 
{
    [SerializeField] AssetLabelReference defaultCardsLabel;
    [SerializeField] private GameObject playerCamera;
    private GameObject mainCamera;

    public int BombCount => bombCount;
    int bombCount;

    public CardObject SelectedCard => selectedCard;
    CardObject selectedCard;

    public HudManager HudManager => hudManager;
    HudManager hudManager;

    public ParameterGoalManager ParameterGoalManager => parameterGoalManager;
    ParameterGoalManager parameterGoalManager;

    EndMenuManager endMenu;
    CrudList<ICard> cardList = new CrudList<ICard>();    

    protected override void Awake()
    {
        base.Awake();
        cardList.LoadList(defaultCardsLabel);
        endMenu = GetComponent<EndMenuManager>();   
        mainCamera = Camera.main.gameObject;
        bombCount = GameManager.Instance.Difficulty.NumberOfBombs;
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

    public void SwitchCamera()
    {
        mainCamera.SetActive(!mainCamera.activeSelf);
        playerCamera.SetActive(!playerCamera.activeSelf);
    }

    public void SelectCard()
    {
        selectedCard = new CardObject(cardList.GetRandomItem());
        Debug.Log(selectedCard.Model.name + " card selected");
    }

    public bool UseBomb()
    {
        if(bombCount <= 0)
        {
            Debug.Log("No more bombs!");
            return false;
        }


        bombCount--;
        return true;
    }

    public void DeselectCard()
    {
        selectedCard = null;
    }

}

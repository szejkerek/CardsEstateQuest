using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameplayManager : Singleton<GameplayManager> 
{
    [SerializeField] AssetLabelReference defaultCardsLabel;
    [SerializeField] private GameObject _playerCamera;
    private GameObject _mainCamera;

    public int BombCount => bombCount;
    int bombCount;

    public CrudList<ICard> CardList => cardList;
    CrudList<ICard> cardList = new CrudList<ICard>();    

    public CardObject SelectedCard => selectedCard;
    CardObject selectedCard;

    //Managers
    public GridManager GridManager => gridManager;
    GridManager gridManager;

    public HudManager HudManager => hudManager;
    HudManager hudManager;

    public ParameterGoalManager ParameterGoalManager => parameterGoalManager;
    ParameterGoalManager parameterGoalManager;

    protected override void Awake()
    {
        base.Awake();
        cardList.LoadList(defaultCardsLabel);
        _mainCamera = Camera.main.gameObject;
        bombCount = GameManager.Instance.Difficulty.NumberOfBombs;
    }

    private void Start()
    {
        hudManager = GetComponent<HudManager>();
        parameterGoalManager = GetComponent<ParameterGoalManager>();
        gridManager = GetComponent<GridManager>();
    }


    public void SwitchCamera()
    {
        _mainCamera.SetActive(!_mainCamera.activeSelf);
        _playerCamera.SetActive(!_playerCamera.activeSelf);
    }

    public void LoadEndMenu()
    {
        SceneLoader.Instance.LoadScene(SceneEnum.EndMenu);
    }

    public void SelectCard()
    {
        selectedCard = new CardObject(CardList.GetRandomItem());
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

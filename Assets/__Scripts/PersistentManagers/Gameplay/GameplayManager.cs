using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// Manages gameplay elements and functionality.
/// </summary>
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

    /// <summary>
    /// Shows the end menu based on whether the player won or not.
    /// </summary>
    public void ShowEndMenu()
    {
        endMenu.Show(parameterGoalManager.DidWin());
    }

    /// <summary>
    /// Switches the active camera between the main camera and player camera.
    /// </summary>
    public void SwitchCamera()
    {
        mainCamera.SetActive(!mainCamera.activeSelf);
        playerCamera.SetActive(!playerCamera.activeSelf);
    }

    /// <summary>
    /// Selects a random card and sets it as the selected card.
    /// </summary>
    public void SelectCard()
    {
        selectedCard = new CardObject(cardList.GetRandomItem());
        Debug.Log(selectedCard.Model.name + " card selected");
    }

    /// <summary>
    /// Uses a bomb if available and reduces the bomb count.
    /// </summary>
    /// <returns>True if a bomb was used; otherwise, false.</returns>
    public bool UseBomb()
    {
        if (bombCount <= 0)
        {
            Debug.Log("No more bombs!");
            return false;
        }


        bombCount--;
        return true;
    }

    /// <summary>
    /// Deselects the currently selected card.
    /// </summary>
    public void DeselectCard()
    {
        selectedCard = null;
    }
}

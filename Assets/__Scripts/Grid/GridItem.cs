using UnityEngine;

/// <summary>
/// Manages interactions and placement of cards on a grid item.
/// </summary>
public class GridItem : MonoBehaviour
{
    [SerializeField] bool isTaken = false;
    [SerializeField] Material _hoverMaterial;
    Material _initialMaterial;
    Renderer _renderer;
    bool hoversOver = false;
    GameplayManager manager;
    GameObject currentBuilding = null;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        manager = GameplayManager.Instance;
        _initialMaterial = _renderer.material;
    }

    private void OnMouseDown()
    {
        if (!hoversOver || isTaken || manager.SelectedCard == null)
            return;

        PlaceCard();
        isTaken = true;
    }

    /// <summary>
    /// Handles the mouse hover behavior over the grid item.
    /// </summary>
    public void OnMouseOver()
    {
        hoversOver = true;
        _renderer.material = _hoverMaterial;
    }

    /// <summary>
    /// Handles the mouse exit behavior from the grid item.
    /// </summary>
    public void OnMouseExit()
    {
        hoversOver = false;
        _renderer.material = _initialMaterial;
    }

    /// <summary>
    /// Places a card on the grid item and sets up necessary components and events.
    /// </summary>
    public void PlaceCard()
    {
        CardObject card = manager.SelectedCard;
        currentBuilding = Instantiate(card.Model, transform.position, transform.rotation);
        Transform meshChild = currentBuilding.transform.Find("Mesh"); // TODO: Replace with a reference based on the model

        DestroyWithBomb bomb = meshChild.gameObject.AddComponent<DestroyWithBomb>();
        bomb.BombUsed += OnBombUsed;
        bomb.BombUsed += GameplayManager.Instance.HudManager.UpdateBombCount;

        meshChild.gameObject.AddComponent<BoxCollider>();

        GameplayManager.Instance.ParameterGoalManager.UpdateGlobalParameters(card.Parameters);
        GameplayManager.Instance.DeselectCard();
        Debug.Log("Placed");
    }

    /// <summary>
    /// Handles the event when a bomb is used, destroying the current building.
    /// </summary>
    public void OnBombUsed()
    {
        if (!GameplayManager.Instance.UseBomb())
            return;

        isTaken = false;
        Destroy(currentBuilding);
        Debug.Log("Destroyed");
    }
}

using UnityEngine;
using UnityEngine.AI;

public class GridItem : MonoBehaviour
{


    [SerializeField] bool isTaken = false;
    [SerializeField] Material _hoverMaterial;
    Material _initalMaterial;
    Renderer _renderer;
    bool hoversOver = false;
    GameplayManager manager;
    GameObject currentBuilding = null;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        manager = GameplayManager.Instance;
        _initalMaterial = _renderer.material;
    }

    private void OnMouseDown()
    {
        if (!hoversOver || isTaken || manager.SelectedCard == null)
            return;

        PlaceCard();
        isTaken = true;
    }

    public void OnMouseOver()
    {
        hoversOver = true;
        _renderer.material = _hoverMaterial;
    }

    public void OnMouseExit()
    {
        hoversOver = false;
        _renderer.material = _initalMaterial;
    }

    public void PlaceCard()
    {
        CardObject card = manager.SelectedCard;
        currentBuilding = Instantiate(card.Model, transform.position, transform.rotation);
        Transform meshChild = currentBuilding.transform.Find("Mesh"); //String yikes TODO: Zmienić na referencje na postawie modelu

        meshChild.gameObject.AddComponent<BoxCollider>();

        GameplayManager.Instance.ParameterGoalManager.UpdateGlobalParameters(card.Parameters);
        GameplayManager.Instance.DeselectCard();

        RebuildNavMesh();

        Debug.Log("Placed");
    }
    public void OnBombUsed()
    {
        if (!GameplayManager.Instance.UseBomb())
            return;

        isTaken = false;
        Destroy(currentBuilding);

        RebuildNavMesh();
    }
    private static void RebuildNavMesh()
    {
        NavMeshSurface navMesh = FindObjectOfType<NavMeshSurface>();
        if (navMesh != null)
        {
            navMesh.BuildNavMesh();
        }
    }
}

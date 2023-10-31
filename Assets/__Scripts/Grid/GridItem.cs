using UnityEngine;

public class GridItem : MonoBehaviour
{
    [SerializeField] bool isTaken = false;
    [SerializeField] Material _hoverMaterial;
    Material _initalMateral;
    Renderer _renderer;
    bool hoversOver = false;
    GameplayManager manager;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        manager = GameplayManager.Instance;
        _initalMateral = _renderer.material;
    }

    private void OnMouseDown()
    {
        if (!hoversOver || isTaken || manager.SelectedCard == null)
            return;

        CardObject card = manager.SelectedCard;

        GameObject building = Instantiate(card.Model, transform.position, transform.rotation);
        card.OnCardPlaced(building);
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
        _renderer.material = _initalMateral;
    }

}

using UnityEngine;

public class GridItem : MonoBehaviour
{
    [SerializeField] bool isTaken = false;
    [SerializeField] Material _hoverMaterial;
    Material _initalMateral;
    Renderer _renderer;
    bool hoversOver = false;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        _initalMateral = _renderer.material;
    }

    private void OnMouseDown()
    {
        if (!hoversOver || isTaken)
            return;

        ICard card = GameplayManager.Instance.CardList.GetRandomItem();
        Instantiate(card.Model, transform.position, transform.rotation);
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

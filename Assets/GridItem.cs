using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GridItem : MonoBehaviour
{
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
        if (!hoversOver)
            return;

        ICard card = GameManager.Instance.CardList.GetRandomCard();
        Instantiate(card.Model, transform.position, transform.rotation);
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

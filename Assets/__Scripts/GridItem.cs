using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/// <summary>
/// Represents an item in a grid, which can be interacted with by clicking and hovering.
/// </summary>
public class GridItem : MonoBehaviour
{
    [SerializeField] bool isTaken = false;
    [SerializeField] Material _hoverMaterial;
    Material _initialMaterial;
    Renderer _renderer;
    bool hoversOver = false;

    private void Awake()
    {
        _renderer = GetComponent < Renderer >();

        _initialMaterial = _renderer.material;
    }

    /// <summary>
    /// Handles the click event when the mouse is pressed on the grid item.
    /// </summary>
    private void OnMouseDown()
    {
        if (!hoversOver && isTaken)
            return;

        ICard card = GameManager.Instance.CardList.GetRandomCard();
        Instantiate(card.Model, transform.position, transform.rotation);
        isTaken = true;
    }

    /// <summary>
    /// Handles the mouse-over event when the mouse pointer is over the grid item.
    /// </summary>
    public void OnMouseOver()
    {
        hoversOver = true;
        _renderer.material = _hoverMaterial;
    }

    /// <summary>
    /// Handles the mouse exit event when the mouse pointer exits the grid item.
    /// </summary>
    public void OnMouseExit()
    {
        hoversOver = false;
        _renderer.material = _initialMaterial;
    }
}

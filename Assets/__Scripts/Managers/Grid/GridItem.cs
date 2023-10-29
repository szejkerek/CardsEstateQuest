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

        CardObject card = new CardObject(GameplayManager.Instance.CardList.GetRandomItem());
        GameObject building = Instantiate(card.Model, transform.position, transform.rotation);
        card.OnCardPlaced();
        ParameterGoalManager.Instance.UpdateGlobalParameters(card.Parameters);
        Transform meshChild = building.transform.Find("Mesh");
        meshChild.gameObject.AddComponent<BoxCollider>();
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

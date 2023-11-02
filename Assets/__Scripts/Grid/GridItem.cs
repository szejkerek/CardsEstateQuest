﻿using UnityEngine;

public class GridItem : MonoBehaviour
{
    [SerializeField] bool isTaken = false;
    [SerializeField] Material _hoverMaterial;
    Material _initalMateral;
    Renderer _renderer;
    bool hoversOver = false;
    GameplayManager manager;
    GameObject currentBuilding = null;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        manager = GameplayManager.Instance;
        _initalMateral = _renderer.material;
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
        _renderer.material = _initalMateral;
    }

    public void PlaceCard()
    {
        CardObject card = manager.SelectedCard;
        currentBuilding = Instantiate(card.Model, transform.position, transform.rotation);
        Transform meshChild = currentBuilding.transform.Find("Mesh"); //String yikes TODO: Zmienić na referencje na postawie modelu

        DestroyWithBomb bomb = meshChild.gameObject.AddComponent<DestroyWithBomb>();
        bomb.BombUsed += OnBombUsed;
        bomb.BombUsed += GameplayManager.Instance.HudManager.UpdateBombCount;

        meshChild.gameObject.AddComponent<BoxCollider>();

        GameplayManager.Instance.ParameterGoalManager.UpdateGlobalParameters(card.Parameters);
        GameplayManager.Instance.DeselectCard();
        Debug.Log("Placed");
    }
    public void OnBombUsed()
    {
        if (!GameplayManager.Instance.UseBomb())
            return;

        isTaken = false;
        Destroy(currentBuilding);
        Debug.Log("Destroyed");
    }
}
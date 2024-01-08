using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GridItem : MonoBehaviour
{
    [SerializeField] bool isTaken = false;
    [SerializeField] Material _hoverMaterial;
    CardObject cardObject;
    Material _initalMaterial;
    Renderer _renderer;
    bool hoversOver = false;
    GameplayManager manager;
    GameObject currentBuilding = null;
    List<GridItem> neighbors = new List<GridItem>();
    int neighborCount = 0;

    GameObject ghostRef = null;


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

        PlaceGhost();
    }

    public void OnMouseExit()
    {
        hoversOver = false;
        RemoveGhost();
        _renderer.material = _initalMaterial;
    }

    public Material ghostMaterial;
    private void PlaceGhost()
    {
        if (ghostRef != null)
            return;

        cardObject = manager.SelectedCard;

        if (cardObject == null)
            return;

        ghostRef = Instantiate(cardObject.Model, transform.position, transform.rotation);

        ApplyGhostMaterialRecursively(ghostRef.transform);
    }

    private void ApplyGhostMaterialRecursively(Transform parent)
    {
        foreach (Renderer renderer in parent.GetComponentsInChildren<Renderer>())
        {
            renderer.material = ghostMaterial;
        }
        foreach (Transform child in parent)
        {
            ApplyGhostMaterialRecursively(child);
        }
    }

    private void RemoveGhost()
    {
        Destroy(ghostRef);
        ghostRef = null;
    }

    public void PlaceCard()
    {
        RemoveGhost();
        cardObject = manager.SelectedCard;
        currentBuilding = Instantiate(cardObject.Model, transform.position, transform.rotation);
        Transform meshChild = currentBuilding.transform.Find("Mesh"); //String yikes TODO: Zmienić na referencje na postawie modelu
       
        meshChild.gameObject.AddComponent<BoxCollider>();

        CalculateAverageParameters();
        GameplayManager.Instance.DeselectCard();

        gameObject.SetActive(false);
        Debug.Log("Placed");
    }



    private void CalculateAverageParameters()
    {
        Vector3 currentPosition = transform.position;
        float x = GameplayManager.Instance.GridManager.gridSpacing.x;
        float y = GameplayManager.Instance.GridManager.gridSpacing.y;
        Vector3[] neighborPositions = {
            currentPosition + new Vector3(x , 0, 0),
            currentPosition + new Vector3(-x, 0, 0),
            currentPosition + new Vector3(0, 0, y),
            currentPosition + new Vector3(0, 0, -y)
        };
        
        float building = cardObject.Parameters[1].Value;
        float green = cardObject.Parameters[0].Value;

        foreach (Vector3 neighborPosition in neighborPositions)
        {
            GridItem neighbor = GameplayManager.Instance.GridManager.GetGridItemAtPosition(neighborPosition);

            if (neighbor != null)
            {
                if (neighbor.cardObject != null)
                {
                    building += neighbor.cardObject.Parameters[1].Value;
                    green += neighbor.cardObject.Parameters[0].Value;
                    neighborCount++;
                }
            }
        }
        float avgBuilding = building / (neighborCount+1); 
        float avgGreen = green / (neighborCount+1);
        GameplayManager.Instance.RoundManager.AddPoint(Mathf.FloorToInt(avgGreen),Mathf.FloorToInt(avgBuilding));
  
    }
}

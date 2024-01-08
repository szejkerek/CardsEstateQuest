using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Object Properties")]
    [SerializeField] private GameObject prefab;

    [Header("Grid Properties")]
    [SerializeField] private Transform gridContainer;
    [SerializeField] private Vector2Int gridSize;
    [SerializeField] public  Vector2 gridSpacing;

    public  GridItem[,] gridItems;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        gridItems = new GridItem[gridSize.x, gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacing.x, 0, y * gridSpacing.y);
                GameObject obj = Instantiate(prefab, spawnPosition, Quaternion.identity);
                obj.transform.parent = gridContainer;

                GridItem gridItem = obj.GetComponent<GridItem>();
                gridItems[x, y] = gridItem;
            }
        }
    }

    public Vector3 GetMinBoundary()
    {
        return new Vector3(0, 0, 0);
    }

    public Vector3 GetMaxBoundary()
    {
        return new Vector3((gridSize.x - 1) * gridSpacing.x, 0, (gridSize.y - 1) * gridSpacing.y);
    }

    public GridItem GetGridItemAtPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x / gridSpacing.x);
        int y = Mathf.RoundToInt(position.z / gridSpacing.y);

        if (x >= 0 && x < gridSize.x && y >= 0 && y < gridSize.y)
        {
            return gridItems[x, y];
        }

        return null;
    }

    // Draw Gizmos for the min and max boundaries
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GetMinBoundary() + GetMaxBoundary() * 0.5f, GetMaxBoundary() - GetMinBoundary());
    }

    // Draw Gizmos only when the object is selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(GetMinBoundary() + GetMaxBoundary() * 0.5f, GetMaxBoundary() - GetMinBoundary());
    }
}

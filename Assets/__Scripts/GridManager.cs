using UnityEngine;

/// <summary>
/// Manages the creation of a grid of objects with specified properties.
/// </summary>
public class GridManager : MonoBehaviour
{
    [Header("Object Properties")]
    [SerializeField] private GameObject prefab;

    [Header("Grid Properties")]
    [SerializeField] private Vector2Int gridSize;
    [SerializeField] private Vector2 gridSpacing;

    private void Awake()
    {
        GenerateGrid();
    }

    /// <summary>
    /// Generates a grid of objects based on the specified grid properties.
    /// </summary>
    void GenerateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacing.x, 0, y * gridSpacing.y);
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}

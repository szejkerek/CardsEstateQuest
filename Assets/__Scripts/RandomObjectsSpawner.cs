using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class RandomObjectsSpawner : MonoBehaviour
{
    List<GameObject> trees;
    List<Transform> possibleTreeSpots;

    //List<GameObject> fountains;
    List<Transform> possibleFountainsSpots;

    private void Start()
    {
        trees = GameManager.Instance.Trees;
        possibleTreeSpots = transform.GetComponentsInChildren<Transform>().Where(go => go.CompareTag("PossibleTreeSpot")).ToList();
        //fountains = loader.Load(fountainsLabel);
        
        PlaceTrees(2);
    }

    public void PlaceTrees(int count)
    {
        if (possibleTreeSpots.Count == 0)
            return;
     
        foreach (var spot in possibleTreeSpots)
        {
            if(Random.Range(0f,1f) <= GameManager.Instance.TreeChance)
            {
                Instantiate(trees.SelectRandomElement(), spot.transform.position, Quaternion.identity);

            }
        }
    }
}

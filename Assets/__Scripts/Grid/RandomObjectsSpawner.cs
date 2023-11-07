using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct CardObjectCompontents
{
    public float spawnChance;
    public List<GameObject> models;
    public List<Transform> possibleSpawns;
}

public class RandomObjectsSpawner : MonoBehaviour
{
    CardObjectCompontents trees;
    CardObjectCompontents fountains;

    private void Start()
    {
        GameManager gm = GameManager.Instance;
        trees = LoadComponent(gm.TreeChance, gm.Trees, "PossibleTreeSpot");
        //fountains = LoadComponent(gm.FoutainChance, gm.Fountains, "PossibleFountainsSpawns");
        
        PlaceObjects(trees);
    }

    private CardObjectCompontents LoadComponent(float spawnChance, List<GameObject> models, string tag)
    {
        CardObjectCompontents temp;
        temp.spawnChance = spawnChance;
        temp.models = models;
        temp.possibleSpawns = transform.GetComponentsInChildren<Transform>().Where(go => go.CompareTag(tag)).ToList();

        if(temp.possibleSpawns.Count == 0 )
        {
            Debug.LogWarning($"{transform.name} has no components of {tag}");
        }

        return temp;
    }

    public void PlaceObjects(CardObjectCompontents objectCompontents)
    {
        if (objectCompontents.possibleSpawns.Count == 0)
            return;
     
        foreach (var spot in objectCompontents.possibleSpawns)
        {
            if(Random.Range(0f,1f) <= GameManager.Instance.TreeChance)
            {
                Instantiate(objectCompontents.models.SelectRandomElement(), spot.transform.position, Quaternion.identity);

            }
        }
    }
}

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
    public Pedestrian pedo;
    public int pedoCount = 5;
    CardObjectCompontents trees;
    CardObjectCompontents fountains;

    private void Start()
    {
        GameManager gm = GameManager.Instance;
        trees = LoadComponent(gm.TreeChance, gm.Trees, "PossibleTreeSpot");
        fountains = LoadComponent(gm.FoutainChance, gm.Fountains, "PossibleFountainSpot");
        
       PlaceObjects(trees);
       PlaceFountains(fountains);
       PlacePedestriants();
    }

    private void PlacePedestriants()
    {
        for (int i = 0; i < pedoCount; i++)
        {
            Pedestrian temp = Instantiate(pedo, Pedestrian.RandomSphere(transform.position, 2.5f), Quaternion.identity);
        }
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
    public void PlaceFountains(CardObjectCompontents objectCompontents)
{
    if (objectCompontents.possibleSpawns.Count == 0)
        return;
     
    foreach (var spot in objectCompontents.possibleSpawns)
    {
        if(Random.Range(0f,1f) <= GameManager.Instance.FoutainChance)
        {
            Instantiate(objectCompontents.models[0], spot.transform.position, Quaternion.identity);
        }
    }
}
}

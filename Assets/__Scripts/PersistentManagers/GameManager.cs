using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] DifficultySO defaultDifficulty;

    [SerializeField] AssetLabelReference treeLabel;
    public float TreeChance => treeChance;
    [SerializeField, Range(0f, 1f)] float treeChance;
    public List<GameObject> Trees => trees;
    List<GameObject> trees;

    [SerializeField] AssetLabelReference fountainsLabel;
    public float FoutainChance => fountainChance;
    [SerializeField, Range(0f, 1f)] float fountainChance;
    public List<GameObject> Fountains => fountains;
    List<GameObject> fountains;

    public IDifficulty Difficulty => difficulty;
    IDifficulty difficulty;

    protected override void Awake()
    {
        base.Awake();
        if(difficulty == null) 
        { 
           SetDifficulty(defaultDifficulty);
        }

        DefaultLoader<GameObject> loader = new DefaultLoader<GameObject>();
        trees = loader.Load(treeLabel);
        //fountains = loader.Load(fountainsLabel);
    }

    public void SetDifficulty(IDifficulty difficulty)
    {
        this.difficulty = difficulty;
        Debug.Log($"Difficulty set to {difficulty.Name}!");
    }

}

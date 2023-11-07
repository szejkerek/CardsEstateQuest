using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] DifficultySO defaultDifficulty;

    [SerializeField] AssetLabelReference treeLabel;
    public float TreeChance => treeChance;
    [SerializeField, Range(0f, 1f)] float treeChance;

    public IDifficulty Difficulty => difficulty;
    IDifficulty difficulty;

    public List<GameObject> Trees => trees;
    List<GameObject> trees;

    protected override void Awake()
    {
        base.Awake();
        if(difficulty == null ) 
        { 
           SetDifficulty(defaultDifficulty);
        }

        DefaultLoader<GameObject> loader = new DefaultLoader<GameObject>();
        trees = loader.Load(treeLabel);
    }

    public void SetDifficulty(IDifficulty difficulty)
    {
        this.difficulty = difficulty;
        Debug.Log($"Difficulty set to {difficulty.Name}!");
    }

}

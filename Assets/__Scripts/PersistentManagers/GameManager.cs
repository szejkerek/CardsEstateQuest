using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] DifficultySO defaultDifficulty;
      
    public IDifficulty Difficulty => difficulty;
    IDifficulty difficulty;

    protected override void Awake()
    {
        base.Awake();
        if(difficulty == null ) 
        { 
           SetDifficulty(defaultDifficulty);
        }
    }

    public void SetDifficulty(IDifficulty difficulty)
    {
        this.difficulty = difficulty;
        Debug.Log($"Difficulty set to {difficulty.Name}!");
    }

}

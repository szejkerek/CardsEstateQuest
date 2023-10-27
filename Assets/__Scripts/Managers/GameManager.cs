using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public IDifficulty Difficulty => difficulty;
    IDifficulty difficulty;

    [SerializeField] DifficultySO defaultDifficulty;

    private void Start()
    {
        difficulty = defaultDifficulty;
    }

    public void SetDifficulty(IDifficulty difficulty)
    {
        this.difficulty = difficulty;
    }
}

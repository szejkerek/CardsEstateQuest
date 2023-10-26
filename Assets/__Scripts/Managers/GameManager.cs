using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public IDifficulty Difficulty => difficulty;
    IDifficulty difficulty;

    public void SetDifficulty(IDifficulty difficulty)
    {
        this.difficulty = difficulty;
    }
}

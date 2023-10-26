using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    IDifficulty difficulty;

    public void SetDifficulty(IDifficulty difficulty)
    {
        this.difficulty = difficulty;
    }
}

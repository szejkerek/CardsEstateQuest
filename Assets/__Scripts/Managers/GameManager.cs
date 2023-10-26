using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    IDifficulty Difficulty => difficulty;
    IDifficulty difficulty;
}

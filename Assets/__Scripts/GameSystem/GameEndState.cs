using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : IRoundState
{
    public void Update(RoundManager roundManager)
    {
        roundManager.DetermineGameWinner();
    }
}

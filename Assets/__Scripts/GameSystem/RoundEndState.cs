using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : IRoundState
{
    public void Update(RoundManager roundManager)
    {
        if (roundManager.GetRoundNumber() < 3)
        {
            roundManager.DeterimneRoundWinner();
            roundManager.TransitionTo(roundManager.RoundPreparationState);
        }
        else
        {
            roundManager.DetermineGameWinner();
        }
    }
}

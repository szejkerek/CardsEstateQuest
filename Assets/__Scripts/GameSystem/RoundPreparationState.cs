using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPreparationState : IRoundState
{
    public void Update(RoundManager roundManager)
    {
        if(roundManager.ThereWasWinnerLastRound())
        {
            roundManager.ActivateRandomWinner();
        }
        else
        {
            roundManager.ActivateRandomPlayer();
        }
        roundManager.ResetWinnerList();
        roundManager.TransitionTo(roundManager.RoundPlayState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPlayState : IRoundState
{
    public void Update(RoundManager roundManager)
    {
        if(roundManager.AllPlayersHasFolded())
        {
            roundManager.TransitionTo(roundManager.RoundEndState);
        }
    }
}

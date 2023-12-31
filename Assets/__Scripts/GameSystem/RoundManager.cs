using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int RoundNumber => roundNumber;

    public RoundPreparationState RoundPreparationState;
    public RoundPlayState RoundPlayState;

    [SerializeField] private List<IPlayer> _players;

    private int roundNumber;
    private List<int> winnersIndexes;
    private IRoundState currentState;
    private void Awake()
    {
        roundNumber = 1;
        winnersIndexes = new List<int>();
        RoundPreparationState =  new RoundPreparationState();
        RoundPlayState = new RoundPlayState();
        currentState = RoundPreparationState;
    }

    void Update()
    {
        currentState.Update(this);
    }
    
    public void TransitionTo(IRoundState state)
    {
        currentState = state;
    }
    public void ActivateRandomPlayer()
    {
        int playersCount = _players.Count;
        int playerToActivate = new System.Random().Next(0, playersCount);

        _players[playerToActivate].SetAsActive();
    }

    public void ActivateRandomWinner()
    {
        int winnersCount = winnersIndexes.Count;
        if (winnersCount > 0)
        {
            int winnerToActivate = new System.Random().Next(0, winnersCount);
            for (int i = 0; i < winnersCount; i++) 
            {
                _players[winnersIndexes[winnerToActivate]].SetAsActive();
            }
        }
    }

    public bool ThereWasWinnerLastRound()
    {
        if (winnersIndexes.Count == 0) 
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ActivateNextPlayer()
    {
        bool currentPlayerDesactivated = false;
        bool nextPlayerActivated = false;
        while (!nextPlayerActivated)
        {
            foreach (IPlayer player in _players)
            {
                if (currentPlayerDesactivated && !nextPlayerActivated)
                {
                    player.SetAsActive();
                    nextPlayerActivated = true;
                }
                if (player.IsActive() && !currentPlayerDesactivated)
                {
                    player.SetAsUnactive();
                    currentPlayerDesactivated = true;
                }
            }
        }
    }

    public void DeterimneWinner()
    {
        float bestScore = -1;
        for (int i = 0; i < _players.Count; i++) 
        {
            if (bestScore <= _players[i].GetPlayerScore())
            {
                bestScore = _players[i].GetPlayerScore();
            }
        }
        for(int i = 0; i < _players.Count; i++) 
        {
            if (_players[i].GetPlayerScore() == bestScore) 
            {
                _players[i].RegisterWin();
                winnersIndexes[i] = i;
            }
        }
    }

    public void FoldActivePlayer()
    {
        foreach (IPlayer player in _players)
        {
            if (player.IsActive())
            {
                player.SetAsFolded();
            }
        }
    }

    public void UnfoldPlayers()
    { 
        foreach (IPlayer player in _players)
        {
            player.SetAsUnfolded();
        }
    }

    public void ResetWinnerList()
    {
        winnersIndexes.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int RoundNumber => roundNumber;

    public RoundPreparationState RoundPreparationState;
    public RoundPlayState RoundPlayState;
    public RoundEndState RoundEndState;
    public GameEndState GameEndState;

    private IPlayer playerOne;
    private IPlayer playerTwo;
    private int roundNumber;
    private List<IPlayer> previousRoundWinners;
    private List<IPlayer> gameWinners;
    private IRoundState currentState;
    private RoundUIManager uiManager;

    private void Awake()
    {
        roundNumber = 0;
        IPlayer[] players = GetComponentsInChildren<IPlayer>();
        playerOne = players[0];
        playerTwo = players[1];
        uiManager = GetComponent<RoundUIManager>();
        previousRoundWinners = new List<IPlayer>();
        gameWinners = new List<IPlayer>();
        RoundPreparationState =  new RoundPreparationState();
        RoundPlayState = new RoundPlayState();
        RoundEndState = new RoundEndState();
        GameEndState = new GameEndState();
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
        int playerToActivate = new System.Random().Next(1, 3);

        if (playerToActivate == 1) 
        {
            playerOne.SetAsActive();
        }
        else
        {
            playerTwo.SetAsActive();
        }

        UpdateActivePlayerUIInfo();
    }

    public void ActivateRandomWinner()
    {
        if (previousRoundWinners.Count > 0)
        {
            int winnerToActivate = new System.Random().Next(0, previousRoundWinners.Count);

            previousRoundWinners[winnerToActivate].SetAsActive();

            UpdateActivePlayerUIInfo();
        }
    }

    private void UpdateActivePlayerUIInfo()
    {
        IPlayer activePlayer = GetActivePlayer();
        uiManager.SetAtivePlayerScoreText(activePlayer.GetPlayerScore().ToString());
        uiManager.SetctivePlayerWinsText(activePlayer.GetPlayerWins().ToString());
        uiManager.SetActivePlayerNameText(activePlayer.GetPlayerName());

    }

    private IPlayer GetActivePlayer()
    {
        if (playerOne.IsActive())
        {
            return playerOne;
        }
        else
        {
            return playerTwo;
        }
    }

    public bool ThereWasWinnerLastRound()
    {
        if (previousRoundWinners.Count == 0) 
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
        IPlayer activePlayer = GetActivePlayer();

        if (activePlayer == playerOne && !playerTwo.HasFolded())
        {
            playerOne.SetAsUnactive();
            playerTwo.SetAsActive();
            UpdateActivePlayerUIInfo();
        }
        else if (activePlayer == playerTwo && !playerOne.HasFolded())
        {
            playerTwo.SetAsUnactive();
            playerOne.SetAsActive();
            UpdateActivePlayerUIInfo();
        }
    }

    public void DeterimneRoundWinner()
    {
        if(playerOne.GetPlayerScore() > playerTwo.GetPlayerScore()) 
        {
            previousRoundWinners.Add(playerOne);
        }
        else if (playerOne.GetPlayerScore() < playerTwo.GetPlayerScore())
        {
            previousRoundWinners.Add(playerTwo);
        }
        else
        {
            previousRoundWinners.Add(playerOne);
            previousRoundWinners.Add(playerTwo);
        }
    }

    public void DetermineGameWinner()
    {
        if (playerOne.GetPlayerWins() > playerTwo.GetPlayerWins())
        {
            gameWinners.Add(playerOne);
            uiManager.SetEndOfGameInfoText(playerOne.GetPlayerName() + " has won!");
        }
        else if (playerOne.GetPlayerWins() < playerTwo.GetPlayerWins())
        {
            gameWinners.Add(playerTwo);
            uiManager.SetEndOfGameInfoText(playerTwo.GetPlayerName() + " has won!");
        }
        else
        {
            gameWinners.Add(playerOne);
            gameWinners.Add(playerTwo);
            uiManager.SetEndOfGameInfoText("Draw!");
        }

        uiManager.ShowEndGameUI();
    }

    public void FoldActivePlayer()
    {
        IPlayer activePlayer = GetActivePlayer();

        if (activePlayer == playerOne)
        {
            playerOne.SetAsFolded();
        }
        else
        {
            playerTwo.SetAsFolded();
        }

        ActivateNextPlayer();
    }

    public void UnfoldPlayers()
    { 
        playerOne.SetAsUnfolded();
        playerTwo.SetAsUnfolded();
    }

    public bool AllPlayersHasFolded()
    {
        if(playerOne.HasFolded() && playerTwo.HasFolded()) 
        {
            return true;
        }

        return false;
    }

    public void ResetWinnerList()
    {
        previousRoundWinners.Clear();
    }

    public void IncreaseRoundNumber()
    {
        roundNumber++;
        uiManager.SetRoundNumberText(roundNumber.ToString());
    }

    public int GetRoundNumber()
    {
        return roundNumber;
    }
}

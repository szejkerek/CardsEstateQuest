using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private string _playerName;

    private float score;
    private int numberOfWins;
    private bool hasFolded;
    private bool isActive;

    private void Awake()
    {
        score = 0;
        numberOfWins = 0;
        hasFolded = false;
        isActive = false;
    }

    public string GetPlayerName()
    {
        return _playerName;
    }

    public float GetPlayerScore()
    {
        return score;
    }

    public int GetPlayerWins()
    {
        return numberOfWins;
    }

    public bool HasFolded()
    {
        return hasFolded;
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void RegisterWin()
    {
        numberOfWins++;
    }

    public void SetAsActive()
    {
        isActive = true;
    }

    public void SetAsFolded()
    {
        hasFolded = true;
    }

    public void SetAsUnactive()
    {
        isActive = false;
    }

    public void SetAsUnfolded()
    {
        hasFolded = false;
    }
}

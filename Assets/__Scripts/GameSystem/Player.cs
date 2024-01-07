using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerRole
{
    Eco,
    Developer
}
public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private string _playerName;

    private float score;
    private int numberOfWins;
    private bool hasFolded;
    private bool isActive;
    private PlayerRole role;

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

    public void AddPoint(int point)
    {
        score+=point;
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

    public PlayerRole GetRole()
    {
        return role;
    }
    private static System.Random random = new System.Random();
    public void SetRandomRole()
    {
        Array values = Enum.GetValues(typeof(PlayerRole));
       
        PlayerRole randomRole = (PlayerRole)values.GetValue(random.Next(values.Length));
        role = randomRole;
    }
    public void SetRole(PlayerRole role)
    {
        this.role = role;
    }
}

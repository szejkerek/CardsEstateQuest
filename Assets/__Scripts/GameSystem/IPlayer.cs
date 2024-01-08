using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    public string GetPlayerName();

    public int GetPlayerWins();

    public float GetPlayerScore();

    public void AddPoint(int point);
    public bool HasFolded();

    public bool IsActive();

    public void SetAsActive();

    public void SetAsUnactive();

    public void SetAsFolded();

    public void SetAsUnfolded();

    public void RegisterWin();

    public PlayerRole GetRole();
    public void SetRandomRole();
}

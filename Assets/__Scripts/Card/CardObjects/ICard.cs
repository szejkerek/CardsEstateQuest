using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    CardFigure Figure { get; }
    CardColor Color { get; }
    Sprite Pictogram { get; }
    List<CardParameterSO> Parameters { get; }
    GameObject Model { get; }
}

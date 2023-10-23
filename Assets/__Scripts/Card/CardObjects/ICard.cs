using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    CardFigure Figure { get; }
    CardColor Color { get; }
    Sprite Pictogram { get; }
    List<CardParameter> Parameters { get; }
    GameObject Model { get; }
}
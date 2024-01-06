using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    CardFigure Figure { get; }
    CardColor Color { get; }
    Sprite Pictogram { get; }
    List<ParameterValue> Parameters { get; }
    GameObject Model { get; }
    int Width { get; }
    int Length { get; }
    Sprite Image { get; }
}

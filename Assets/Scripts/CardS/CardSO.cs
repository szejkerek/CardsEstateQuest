using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card/Card")]
public class CardSO : ScriptableObject
{
    [field: SerializeField] public CardFigure Fiugure { private set; get; }
    [field: SerializeField] public CardColor Color { private set; get; }
    [field: SerializeField] public Sprite Pictogram { private set; get; }
    [field: SerializeField] public List<CardParameter> Parameters { private set; get; }
    [field: SerializeField] public GameObject Model { private set; get; }
}

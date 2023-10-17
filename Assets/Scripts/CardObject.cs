using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card/Card")]
public class CardObject : ScriptableObject
{
    public Card cardInfo;
    public Sprite pictogram;
    public List<CardParameter> parameters = new List<CardParameter>();
    public GameObject model;
}

[CreateAssetMenu(fileName = "CardParameter", menuName = "Card/CardParameter")]
public class CardParameter : ScriptableObject
{
    public int points;
    public string category;
}

[System.Serializable]
public class Card
{
    public CardFigure fiugure;
    public CardColor color;
}

[System.Serializable]
public enum CardColor
{
    Spades,
    Diamonds,
    Clubs,
    Hearts
}

[System.Serializable]
public enum CardFigure
{
    Ace,
    Number2,
    Number3,
    Number4,
    Number5,
    Number6,
    Number7,
    Number8,
    Number9,
    Number10,
    Jack,
    Queen,
    King
}

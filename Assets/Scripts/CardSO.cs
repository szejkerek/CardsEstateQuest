using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card/Card")]
public class CardSO : ScriptableObject
{
    public Card cardInfo;
    public Sprite pictogram;
    public List<CardParameter> parameters = new List<CardParameter>();
    public GameObject model;
}

public class CardObject
{
    public Card cardInfo;
    public Sprite pictogram;
    public List<CardParameter> parameters = new List<CardParameter>();
    public GameObject model;

    public CardObject(CardSO cardSO)
    {
        cardInfo = cardSO.cardInfo;
        pictogram = cardSO.pictogram;
        parameters = cardSO.parameters;
        model = cardSO.model;
    }

    public CardObject(Card _cardInfo, Sprite _sprite, List<CardParameter> _cardParameters, GameObject _model)
    {
        cardInfo = _cardInfo;
        pictogram = _sprite;
        parameters = _cardParameters;
        model = _model;
    }
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

using System.Collections.Generic;
using UnityEngine;

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

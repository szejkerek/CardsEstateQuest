using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardItem : MonoBehaviour
{
    private CardObject card;

    public void Initialize(CardObject _card)
    {
        card = _card;
    }

    public void onClick()
    {
        GameplayManager.Instance.SetSelectedCard(card);
    }

    public CardObject GetCard()
    {
        return card;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class CardItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CardObject card;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOScale(Vector3.one, 0.3f);
    }
}
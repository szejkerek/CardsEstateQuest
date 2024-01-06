using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour
{
    [SerializeField ]private  List<CardSO> cards;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform spawnPosition;

    private GameplayManager gameplayManager;
    void Start()
    {
         List<CardSO> selectedCards = SelectRandomCards(4);
        foreach (CardSO card in selectedCards)
        {
            AddCardToHolder(card);
        }
    }

    void AddCardToHolder(CardSO card)
    {
        GameObject cardInstance = Instantiate(cardPrefab, spawnPosition);
      cardInstance.GetComponent<Image>().sprite = card.Image;
    }

    List<CardSO> SelectRandomCards(int count)
    {
        List<CardSO> selectedCards = new List<CardSO>();
        List<CardSO> availableCards = new List<CardSO>(cards);

        for (int i = 0; i <count; i++)
        {
            int randomIndex = Random.Range(0, availableCards.Count);
            selectedCards.Add(availableCards[randomIndex]);
            availableCards.RemoveAt(randomIndex);
        }

        return selectedCards;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour
{
    [SerializeField ]private  List<CardSO> cards;
    List<CardObject> selectedCards;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform spawnPosition1;
 
 
    void Start()
    {
        selectedCards = SelectRandomCards(4);
        foreach (CardObject card in selectedCards)
        {
            if(spawnPosition1 != null )
            AddCardToHolder(card, spawnPosition1);
        }
       
    }

    void AddCardToHolder(CardObject card, Transform spawnPosition)
    {
        GameObject cardInstance = Instantiate(cardPrefab, spawnPosition);
      cardInstance.GetComponent<Image>().sprite = card.Image;

        CardItem cardItem = cardInstance.GetComponent<CardItem>();
        cardItem.Initialize(card);
    }

    List<CardObject> SelectRandomCards(int count)
    {
        List<CardObject> selectedCards = new List<CardObject>();
        List<CardObject> availableCards = new List<CardObject>();
        foreach (CardSO card in cards)
        {
           availableCards.Add(new CardObject(card));
        }
        

        for (int i = 0; i <count; i++)
        {
            int randomIndex = Random.Range(0, availableCards.Count);
            selectedCards.Add(availableCards[randomIndex]);
            availableCards.RemoveAt(randomIndex);
        }

        return selectedCards;
    }

    public void RemoveCard(CardObject card)
    {
        selectedCards.Remove(card);

        CardItem[] cardItems = FindObjectsOfType<CardItem>().Where(item => item.GetCard() == card).ToArray();

        // Usuñ wszystkie znalezione obiekty CardItem
        foreach (CardItem item in cardItems)
        {
            Destroy(item.gameObject);
        }
    }
   
}

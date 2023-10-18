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

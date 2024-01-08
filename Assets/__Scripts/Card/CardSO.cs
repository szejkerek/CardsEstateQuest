using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardDefault", menuName = "Card/CardObject")]
public class CardSO : ScriptableObject, ICard
{
    [field: SerializeField] public CardFigure Figure { private set; get; }
    [field: SerializeField] public CardColor Color { private set; get; }
    [field: SerializeField] public Sprite Pictogram { private set; get; }
    [field: SerializeField] public List<ParameterValue> Parameters { private set; get; }
    [field: SerializeField] public GameObject Model { private set; get; }
    [field: SerializeField] public Sprite Image { private set; get; }

    [field: SerializeField] public int Width { private set; get; }
    [field: SerializeField] public int Length { private set; get; }
    
}

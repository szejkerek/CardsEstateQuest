using UnityEngine;

[CreateAssetMenu(fileName = "CardParameter", menuName = "Card/CardParameter")]
public class CardParameter : ScriptableObject
{
    [field: SerializeField] public int Points { private set; get; }
    [field: SerializeField] public string Category { private set; get; }
}

using UnityEngine;

[CreateAssetMenu(fileName = "CardParameter", menuName = "Card/CardParameter")]
public class CardParameterSO : ScriptableObject
{
    [field: SerializeField] public string Category { private set; get; }
}


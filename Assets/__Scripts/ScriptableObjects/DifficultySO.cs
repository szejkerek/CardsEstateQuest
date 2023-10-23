using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultDifficulty", menuName = "Difficulty", order = 1)]
public class DifficultySO : ScriptableObject, IDifficulty
{
    [field: SerializeField] public string Name { private set; get; }
    [field: SerializeField] public Sprite Icon { private set; get; }
    [field: SerializeField] public CardParameter CardParameter { private set; get; }
    [field: SerializeField] public int NumberOfParameters { private set; get; }
    [field: SerializeField] public int NumberOfBombs { private set; get; }
}

﻿using UnityEngine;

/// <summary>
/// A ScriptableObject representing a card parameter.
/// </summary>
[CreateAssetMenu(fileName = "CardParameter", menuName = "Card/CardParameter")]
public class CardParameterSO : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { private set; get; }
    [field: SerializeField] public string Category { private set; get; }
    [field: SerializeField] public ParameterTypeEnum ValueType { private set; get; }
}

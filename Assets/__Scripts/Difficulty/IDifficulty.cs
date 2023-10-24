using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDifficulty
{
    string Name { get; }
    Sprite Icon { get; }
    List<ParameterMinMax> CardParameters { get; }
    int NumberOfParameters { get; }
    int NumberOfBombs { get; }

}

[System.Serializable]
public class ParameterMinMax
{
    public CardParameterSO Parameter => parameter;
    [SerializeField] CardParameterSO parameter;

    public float Min => min;
    [SerializeField] float min;

    public float Max => max;
    [SerializeField] float max;
}
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
    int parameter;
    float min;
    float max;
}
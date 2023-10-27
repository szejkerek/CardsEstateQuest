using UnityEngine;

[System.Serializable]
public class ParameterRule : Parameter
{
    public float MaxValue => maxValue;
    [SerializeField] private float maxValue;
    public float MinValue => minValue;
    [SerializeField] private float minValue;
    
}


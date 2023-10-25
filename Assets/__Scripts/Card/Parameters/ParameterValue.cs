using UnityEngine;

[System.Serializable]
public class ParameterValue: Parameter
{
    public float Value => value;   
    [SerializeField] private float value;
}


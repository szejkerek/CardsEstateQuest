using UnityEngine;

[System.Serializable]
public class ParameterValue: Parameter
{
    public ParameterValue(string category)
    {
        SetCategory(category);
        value = 0;
    }

    public float Value => value;   
    [SerializeField] private float value;
}


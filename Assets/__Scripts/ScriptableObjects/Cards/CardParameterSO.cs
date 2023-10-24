using UnityEngine;

[CreateAssetMenu(fileName = "CardParameter", menuName = "Card/CardParameter")]
public class CardParameterSO : ScriptableObject, IParameter
{
    [field: SerializeField] public string Category { private set; get; }
}

public interface IParameter
{
    string Category { get; }
}

[System.Serializable]
public class CardParameter : IParameter
{
    public string Category => _category;

    [SerializeField] private string _category;

    public CardParameter(string category)
    {
        _category = category;
    }
}
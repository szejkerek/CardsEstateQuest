using UnityEngine;

/// <summary>
/// Represents a scriptable object for card parameters, such as points and category.
/// </summary>
[CreateAssetMenu(fileName = "CardParameter", menuName = "ICard/CardParameter")]
public class CardParameter : ScriptableObject
{
    /// <summary>
    /// Gets or sets the points associated with the card parameter.
    /// </summary>
    [field: SerializeField]
    public int Points { private set; get; }

    /// <summary>
    /// Gets or sets the category of the card parameter.
    /// </summary>
    [field: SerializeField]
    public string Category { private set; get; }
}

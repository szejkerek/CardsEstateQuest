using UnityEngine;

/// <summary>
/// Represents a parameter with a category and provides methods to access related data.
/// </summary>
public class Parameter
{
    private string _category;

    [SerializeField] private CardParameterSO _categorySO;

    /// <summary>
    /// Sets the category for the parameter.
    /// </summary>
    public void SetCategory(string category)
    {
        _category = category;
    }

    /// <summary>
    /// Gets the value type for the parameter.
    /// </summary>
    public ParameterTypeEnum GetValueType()
    {
        if (_categorySO != null)
        {
            return _categorySO.ValueType;
        }

        return ParameterTypeEnum.Decimal;
    }

    /// <summary>
    /// Tries to get the icon associated with the parameter's category.
    /// </summary>
    /// <param name="icon">The retrieved icon if successful.</param>
    /// <returns>True if an icon is found; otherwise, false.</returns>
    public bool TryGetIcon(out Sprite icon)
    {
        if (_categorySO != null && _categorySO.Icon != null)
        {
            icon = _categorySO.Icon;
            return true;
        }
        icon = null;
        return false;
    }

    /// <summary>
    /// Gets the category associated with the parameter.
    /// </summary>
    public string GetCategory()
    {
        if (_categorySO != null)
        {
            return _categorySO.Category;
        }
        return _category;
    }
}

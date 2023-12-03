using UnityEngine;

public class Parameter
{
    private string _category;

    [SerializeField] private CardParameterSO _categorySO;
    public void SetCategory(string category)
    {
        _category = category;
    }
    public ParameterTypeEnum GetValueType()
    {
        if (_categorySO != null)
        {
            return _categorySO.ValueType;
        }

        return ParameterTypeEnum.Decimal;
    }

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

    public string GetCategory()
    {
        if (_categorySO != null)
        {
            return _categorySO.Category;
        }
        return _category;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDifficulty
{
    string Name { get; }
    Sprite Icon { get; }
    List<ParameterRule> CardParameters { get; }
}

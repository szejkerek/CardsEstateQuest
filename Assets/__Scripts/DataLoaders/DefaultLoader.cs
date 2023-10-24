using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefaultLoader<T> : IDataLoader<T>
{
    public List<T> LoadCards(string path)
    {
        object[] cards = Resources.LoadAll(path, typeof(T));
        return cards.OfType<T>().ToList();
    }
}

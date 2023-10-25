using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefaultLoader<T> : IDataLoader<T>
{
    public List<T> Load(string path)
    {
        object[] cards = Resources.LoadAll(path, typeof(T));
        List<T> result = cards.OfType<T>().ToList();
        if(result.Count == 0)
        {
            Debug.LogError($"Did not load list for {path} path");
            return null;
        }
        return result;
    }
}

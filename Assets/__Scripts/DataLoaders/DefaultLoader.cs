using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DefaultLoader<T>
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

    public List<T> Load(AssetLabelReference label)
    {
        List<T> result = new List<T>();
        var loadOperation = Addressables.LoadAssetsAsync<T>(label, result.Add).WaitForCompletion();

        if (result.Count == 0)
        {
            Debug.LogError($"Did not load list for {label.labelString} path");
            return null;
        }

        return result;
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// A generic class for loading objects of type T from resources or AddressableAssets.
/// </summary>
public class DefaultLoader<T>
{
    /// <summary>
    /// Loads a list of objects of type T from the specified resource path.
    /// </summary>
    /// <param name="path">The path to the resources.</param>
    /// <returns>A list of loaded objects of type T.</returns>
    public List<T> Load(string path)
    {
        object[] cards = Resources.LoadAll(path, typeof(T));
        List<T> result = cards.OfType<T>().ToList();
        if (result.Count == 0)
        {
            Debug.LogError($"Did not load list for {path} path");
            return null;
        }
        return result;
    }

    /// <summary>
    /// Loads a list of objects of type T from AddressableAssets using the provided label.
    /// </summary>
    /// <param name="label">The label reference for AddressableAssets.</param>
    /// <returns>A list of loaded objects of type T.</returns>
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

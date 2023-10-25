using System.Collections.Generic;

public class FileDataLoader<T> : IDataLoader<T>
{
    public List<T> Load(string path)
    {
        throw new System.NotImplementedException();
    }

    //if(result.Count == 0)
    //{
    //    Debug.LogError($"Did not load list for {path} path");
    //    return null;
    //}
    //return result;
}
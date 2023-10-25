using System.Collections.Generic;

public interface IDataLoader<T>
{
    public List<T> Load(string path);
}

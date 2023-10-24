using System.Collections.Generic;

public interface IDataLoader<T>
{
    public List<T> LoadCards(string path);
}

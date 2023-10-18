using System.Collections.Generic;

public interface ICardLoader
{
    public List<CardObject> LoadCards(string path);
}

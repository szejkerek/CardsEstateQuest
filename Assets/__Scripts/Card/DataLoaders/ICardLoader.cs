using System.Collections.Generic;

public interface ICardLoader
{
    public List<ICard> LoadCards(string path);
}

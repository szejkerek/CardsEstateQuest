using System.Collections.Generic;

public class DefaultCardLoader : ICardLoader
{
    List<CardObject> ICardLoader.LoadCards(string path = null)
    {
        throw new System.NotImplementedException();
    }
}

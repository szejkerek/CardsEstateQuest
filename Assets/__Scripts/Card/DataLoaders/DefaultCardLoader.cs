using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefaultCardLoader : ICardLoader
{
    public List<ICard> LoadCards(string path)
    {
        System.Object[] cards = Resources.LoadAll(path, typeof(ICard));
        return cards.OfType<ICard>().ToList();
    }
}

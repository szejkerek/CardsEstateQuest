using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CrudListTest
{
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(15)]
    [TestCase(765)]
    public void TestListPositiveGetter(int listSize)
    {
        CrudList<int> list = new CrudList<int>();

        for (int i = 0; i < listSize; i++)
        {
            list.AddItem(i);
        }    

        Assert.AreEqual(listSize, list.GetItem(listSize));
    }
}

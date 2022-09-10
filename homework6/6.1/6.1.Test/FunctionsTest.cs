using NUnit.Framework;
using Task6_1;
using System.Collections.Generic;

namespace FunctionsTest;

public class Tests
{   
    private List<int> list = new List<int>() { 1, 2, 3, 4 };
    private List<int> emptyList = new List<int>() { };   

    [Test]
    public void MapTest()
    {
        Assert.AreEqual(Functions.Map(list, x => x * 2), new List<int>() { 2, 4, 6, 8 });
        Assert.AreEqual(Functions.Map(list, x => x * x), new List<int>() { 1, 4, 9, 16 });
        Assert.AreEqual(Functions.Map(list, x => x - 10), new List<int>() { -9, -8, -7, -6 });
        Assert.AreEqual(Functions.Map(emptyList, x => x + 10), new List<int>() { });
    }

    [Test]
    public void FilterTest()
    {
        Assert.AreEqual(Functions.Filter(list, x => x % 2 == 0), new List<int>() { 2, 4 });
        Assert.AreEqual(Functions.Filter(list, x => x % 2 == 1), new List<int>() { 1, 3 });
        Assert.AreEqual(Functions.Filter(list, x => x > 10), new List<int>() { });
        Assert.AreEqual(Functions.Filter(emptyList, x => x < 10), new List<int>() { });
    }

    [Test]
    public void FoldTest()
    {
        Assert.AreEqual(Functions.Fold(list, 1, (x, y) => x + y), 11);
        Assert.AreEqual(Functions.Fold(list, 1, (x, y) => x * y), 24);
        Assert.AreEqual(Functions.Fold(list, 1, (x, y) => x - y), -9);
        Assert.AreEqual(Functions.Fold(emptyList, 1, (x, y) => x * y), 1);
    }
}


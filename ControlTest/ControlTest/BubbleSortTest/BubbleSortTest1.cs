using NUnit.Framework;
using Sorting;
using System.Collections.Generic;
using Comparing;

namespace BubbleSortTest;

public class Tests
{ 
    static object[] Cases =
    {
        new object[] { new List<int>(), new List<int>() }, 
        new object[] { new List<int> { 7, 6, 10, 3, 5, 8, 7, 99 }, new List<int> { 3, 5, 6, 7, 7, 8, 10, 99 } },
        new object[] { new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 3 } }
    };

    [TestCaseSource(nameof(Cases))]
    public void BubbleSortTest(List<int> list, List<int> expectedList)
    {   
        CompareInt comparer = new CompareInt();   
        Sort.BubbleSort(list, comparer);
        Assert.AreEqual(expectedList, list);
    }

    [Test]
    public void BubbleSortListStringsTest()
    {
        var list = new List<string> { "kkk", "bc", "abd" };
        var expectedList = new List<string> { "abd", "bc", "kkk" };
        CompareString comparer = new CompareString();
        Sort.BubbleSort(list, comparer);
        Assert.AreEqual(expectedList, list);
    }
}

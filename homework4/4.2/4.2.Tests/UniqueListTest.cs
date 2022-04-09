using NUnit.Framework;
using _4._2.Exception;
namespace _4._2.Tests;

public class TestsUniqueList
{   
    private UniqueList list = new UniqueList();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddValue()
    {
        list.Add(100, 0);
        list.Add(101, 1);
        Assert.Throws<AddException>(() => list.Add(100, 2));
    }
}

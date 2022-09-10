using NUnit.Framework;
using Task4_2.Exception;
namespace Task4_2.Tests;

public class TestsUniqueList
{   
    private UniqueList list = new UniqueList();

    [Test]
    public void AddValue()
    {
        list.Add(100, 0);
        list.Add(101, 1);
        Assert.Throws<AddException>(() => list.Add(100, 2));
    }
    [Test]
    public void RemoveByInvalidPositionTest()
    {
        Assert.Throws<InvalidPositionException>(() => list.Remove(10));
        Assert.Throws<InvalidPositionException>(() => list.Remove(-10));
    }

    [Test()]
    public void ChangeValueTest()
    {
        list.Add(0, 0);
        list.Add(1, 1);
        Assert.Throws<AddException>(() => list.ChangeValue(1, 1));
    }
}
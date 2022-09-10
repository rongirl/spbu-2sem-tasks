using NUnit.Framework;
using Task4_2.Exception;

namespace Task4_2.Tests;

public class TestsList
{
    private List list = new();

    [Test]
    public void AddValueByInvalidPositionTest()
    {
        Assert.Throws<InvalidPositionException>(() => list.Add(100, 1));
        Assert.Throws<InvalidPositionException>(() => list.Add(5, -1));
    }

    [Test]
    public void RemoveByInvalidPositionTest()
    {
        Assert.Throws<InvalidPositionException>(() => list.Remove(10));
        Assert.Throws<InvalidPositionException>(() => list.Remove(-10));
    }

    [Test]
    public void ChangeValueByInvalidPositionTest()
    {
        Assert.Throws<InvalidPositionException>(() => list.ChangeValue(900, 10));
        Assert.Throws<InvalidPositionException>(() => list.ChangeValue(666, -10));
    }

    [Test]
    public void ContainTest()
    {
        list.Add(100, 0);
        list.Add(33, 1);
        Assert.IsTrue(list.Contain(33));
        Assert.IsTrue(list.Contain(100));
        Assert.IsFalse(list.Contain(2));
    }
}   

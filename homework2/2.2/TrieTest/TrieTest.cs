using NUnit.Framework;
using TrieSpace;

namespace TrieTest;

public class Test
{
    private Trie trie = new();

    [SetUp]
    public void Setup()
    {
        trie = new();
    }

    [Test]
    public void EmptyTrieAndRemoveTest()
    {
        Assert.IsFalse(trie.Remove("ololol"));
    }

    [Test]
    public void AddTest()
    {
        Assert.IsTrue(trie.Add("ololol"));
        Assert.IsFalse(trie.Add("ololol"));
    }

    [Test]
    public void ContainTest()
    {
        Assert.IsFalse(trie.Contain("ololol"));
    }

    [Test]
    public void AddAndContainTest()
    {
        Assert.IsTrue(trie.Add("ololol"));
        Assert.IsTrue(trie.Contain("ololol"));
    }

    [Test]
    public void AddAndRemoveTest()
    {
        Assert.IsTrue(trie.Add("ololol"));
        Assert.IsTrue(trie.Remove("ololol"));
        Assert.IsFalse(trie.Remove("ololol"));
    }

    [Test]
    public void AddAndRemoveAndContainTest()
    {
        Assert.IsTrue(trie.Add("ololol"));
        Assert.IsTrue(trie.Remove("ololol"));
        Assert.IsFalse(trie.Contain("ololol"));
    }

    [Test]
    public void HowManyStartsWithPrefixTest()
    {
        Assert.IsTrue(trie.Add("ololol"));
        Assert.IsTrue(trie.Add("olo"));
        Assert.AreEqual(2, trie.HowManyStartsWithPrefix("olo"));
    }

    [Test]
    public void HowManyStartsPrefixStringNoContain()
    {
        Assert.IsTrue(trie.Add("ololol"));
        Assert.IsTrue(trie.Add("kekekek"));
        Assert.AreEqual(0, trie.HowManyStartsWithPrefix("aaaaa"));
    }
}

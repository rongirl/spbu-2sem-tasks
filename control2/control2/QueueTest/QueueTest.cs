using NUnit.Framework;
using Task;

namespace QueueTest;

public class Tests
{
    private Queue queue = new Queue();

    [Test]
    public void EnqueueTest()
    {
        queue.Enqueue("abc", 22);
        queue.Enqueue(123, 1000);
        Assert.AreEqual(queue.GetHeadValue(), 123);
        Assert.AreEqual(queue.GetHeadPriority(), 1000);
        Assert.True(queue.IsContain("abc"));
        Assert.False(queue.IsContain("hhh"));
    }

    [Test]
    public void EnqueueElementsWithSamePriorityTest()
    {
        queue.Enqueue("abc", 1000);
        queue.Enqueue(23232, 1000);
        queue.Enqueue(0.3433, 1000);
        Assert.AreEqual(queue.GetHeadValue(), "abc");
    }
}

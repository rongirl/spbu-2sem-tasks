using NUnit.Framework;
using Task;

namespace QueueTest;

public class Tests
{

    [Test]
    public void EnqueueTest()
    {
        Queue queue = new Queue();  
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
        Queue queue = new Queue();
        queue.Enqueue("abc", 1000);
        queue.Enqueue(23232, 1000);
        queue.Enqueue(0.3433, 1000);
        Assert.AreEqual(queue.GetHeadValue(), "abc");
    }
    
    [Test]
    public void IsEmptyTest()
    {
        Queue queue = new Queue();
        Assert.True(queue.IsEmpty());
        queue.Enqueue(11, 11);
        Assert.False(queue.IsEmpty());
    }
}

using NUnit.Framework;
using Task2_1;
using System.Collections.Generic;

namespace StackTest;

public class StackTest
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
             new TestCaseData(new StackArray()),
             new TestCaseData(new StackList())
        };

    [TestCaseSource(nameof(Stacks))]
    public void PushThenStackIsNotEmpty(IStack stack)
    {
        Assert.IsTrue(stack.IsEmpty());
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PushAndPopShallGetExpectedValue(IStack stack)
    {
        stack.Push(1);
        Assert.AreEqual(1, stack.Pop());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PushAndPopShallLeaveStackEmpty(IStack stack)
    {
        stack.Push(1);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void Push_1_2_3_Pop_3_2_1(IStack stack)
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Assert.AreEqual(3, stack.Pop());
        Assert.AreEqual(2, stack.Pop());
        Assert.AreEqual(1, stack.Pop());
    }
}
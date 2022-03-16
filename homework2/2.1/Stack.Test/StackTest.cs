using NUnit.Framework;
using _2._1;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTest
{
    public class StackTest
    {
        private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
             new TestCaseData(new StackArray()),
             new TestCaseData(new StackList())
        };

        [Test, TestCaseSource(nameof(Stacks))]
        public void PushThenStackIsNotEmpty(IStack stack)
        {
            var result = stack.IsEmpty();
            stack.Push(1);
            result = result && !stack.IsEmpty();
            Assert.IsTrue(result);
        }

        [Test, TestCaseSource(nameof(Stacks))]
        public void PushAndPopShallGetExpectedValue(IStack stack)
        {
            stack.Push(1);
            var value = stack.Pop();
            Assert.AreEqual(1, value);
        }

        [Test, TestCaseSource(nameof(Stacks))]
        public void PushAndPopShallLeaveStackEmpty(IStack stack)
        {
            stack.Push(1);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test, TestCaseSource(nameof(Stacks))]
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
}


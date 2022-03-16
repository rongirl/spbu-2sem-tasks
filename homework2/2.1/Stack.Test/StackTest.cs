using NUnit.Framework;
using _2._1;
using System.Collections.Generic;

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
    }

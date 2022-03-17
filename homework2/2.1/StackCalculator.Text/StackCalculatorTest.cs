using NUnit.Framework;
using _2._1;
using System.Collections.Generic;
using System;

namespace StackCalculatorTest
{
    public class StackCalculatorTest
    {
        private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
             new TestCaseData(new StackArray()),
             new TestCaseData(new StackList())
        };

        [Test, TestCaseSource(nameof(Stacks))]
        public void DivisionByZero(IStack stack)
        {
            Assert.Throws<DivideByZeroException>(() => { StackCalculator.Calculate("1 0 /", stack); });
        }

        [Test, TestCaseSource(nameof(Stacks))]
        public void IncorrectInput(IStack stack)
        {
            Assert.Throws<InvalidOperationException>(() => { StackCalculator.Calculate("aaaa", stack); });
            Assert.Throws<InvalidOperationException>(() => { StackCalculator.Calculate("1 2 3 +", stack); });
        }

        [Test, TestCaseSource(nameof(Stacks))]
        public void CorrectAnswer(IStack stack)
        {
            Assert.AreEqual(StackCalculator.Calculate("10 2 * 5 / 4 +", stack), 8);
            Assert.AreEqual(StackCalculator.Calculate("6 4 / 7 *", stack), 10.5);
            Assert.AreEqual(StackCalculator.Calculate("0 5 +", stack), 5);
            Assert.AreEqual(StackCalculator.Calculate("0 5 -", stack), -5);
            Assert.AreEqual(StackCalculator.Calculate("0 9 /", stack), 0);
        }

        [Test, TestCaseSource(nameof(Stacks))]
        public void NegativeNumbers(IStack stack)
        {
            Assert.AreEqual(StackCalculator.Calculate("-10 2 * 5 / 4 +", stack), 0);
            Assert.AreEqual(StackCalculator.Calculate("-6 -4 / -7 *", stack), -10.5);
            Assert.AreEqual(StackCalculator.Calculate("0 -5 +", stack), -5);
            Assert.AreEqual(StackCalculator.Calculate("0 -5 -", stack), 5);
            Assert.AreEqual(StackCalculator.Calculate("-9 -9 /", stack), 1);
        }
    }
}
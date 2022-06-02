using NUnit.Framework;
using Task2_1
using System.Collections.Generic;
using System;

namespace StackCalculatorTest;

public class StackCalculatorTest
{
    private static IEnumerable<TestCaseData> Stacks
    => new TestCaseData[]
    {
         new TestCaseData(new StackArray()),
         new TestCaseData(new StackList())
    };

    [TestCaseSource(nameof(Stacks))]
    public void DivisionByZero(IStack stack)
    {
        Assert.Throws<DivideByZeroException>(() => StackCalculator.Calculate("1 0 /", stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void IncorrectInput(IStack stack)
    {
        Assert.Throws<InvalidOperationException>(() => StackCalculator.Calculate("aaaa", stack));
        Assert.Throws<InvalidOperationException>(() => StackCalculator.Calculate("1 2 3 +", stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CorrectAnswer(IStack stack)
    {
        Assert.AreEqual(8, StackCalculator.Calculate("10 2 * 5 / 4 +", stack));
        Assert.AreEqual(10.5, StackCalculator.Calculate("6 4 / 7 *", stack));
        Assert.AreEqual(5, StackCalculator.Calculate("0 5 +", stack));
        Assert.AreEqual(-5, StackCalculator.Calculate("0 5 -", stack));
        Assert.AreEqual(0, StackCalculator.Calculate("0 9 /", stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void NegativeNumbers(IStack stack)
    {
        Assert.AreEqual(0, StackCalculator.Calculate("-10 2 * 5 / 4 +", stack));
        Assert.AreEqual(-10.5, StackCalculator.Calculate("-6 -4 / -7 *", stack));
        Assert.AreEqual(-5, StackCalculator.Calculate("0 -5 +", stack));
        Assert.AreEqual(5, StackCalculator.Calculate("0 -5 -", stack));
        Assert.AreEqual(1, StackCalculator.Calculate("-9 -9 /", stack));
    }
}
using NUnit.Framework;
using System;
using Task7_1;

namespace CalculatorTest;

public class Tests
{
    private Calculator calculator = new();

   [SetUp]
    public void SetUp()
    {
        calculator = new Calculator();
    }

    [Test]
    public void DivideByZeroTest()
    {
        calculator.AddNumber(4);
        calculator.AddNumber(0);
        calculator.AddOperation('/');
        Assert.Throws<DivideByZeroException>(() => calculator.Calculate());
    }

    [Test]
    public void InvalidOperationTestTwoNumbers()
    {
        calculator.AddNumber(4);
        calculator.AddNumber(5);
        Assert.Throws<InvalidOperationException>(() => calculator.Calculate());
    }

    [Test]
    public void InvalidOperationTestThreeNumbers()
    {
        calculator.AddNumber(4);
        calculator.AddNumber(5);
        calculator.AddNumber(0);
        Assert.Throws<InvalidOperationException>(() => calculator.Calculate());
    }

    [TestCase('+', 15)]
    [TestCase('-', 5)]
    [TestCase('*', 50)]
    [TestCase('/', 2)]
    public void CalculateTests(char operation, double result)
    {
        calculator.AddNumber(10);
        calculator.AddNumber(5);
        calculator.AddOperation(operation);
        Assert.AreEqual(result, calculator.Calculate());
    }

    [Test]
    public void CalculateAndClearTest()
    {
        calculator.AddNumber(4);
        calculator.AddNumber(5);
        calculator.AddOperation('+');
        Assert.AreEqual(9, calculator.Calculate());
        calculator.Clear();
        Assert.Throws<InvalidOperationException>(() => calculator.Calculate());
        calculator.AddNumber(10);
        calculator.AddNumber(2);
        calculator.AddOperation('*');
        Assert.AreEqual(20, calculator.Calculate());
    }
}
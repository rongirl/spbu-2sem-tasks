using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_1;

public class Calculator
{
    private double? numberOne;
    private double? numberTwo;
    private char? operation;

    public void AddNumber(double number)
    {
        if (numberOne == null)
        {
            numberOne = number;
            return;
        }
        numberTwo = number;
    }

    public void AddOperation(char operation) => this.operation = operation;

    public void Clear()
    {
        numberOne = null;
        numberTwo = null;
        operation = null;
    }

    public double? Calculate()
    {
        if (numberTwo == null || numberOne == null)
        {
            throw new InvalidOperationException();
        }
        switch (operation)
        {
            case '+':
            {
                return numberOne + numberTwo;
            }
            case '-':
            {                    
                return numberOne - numberTwo;
            }
            case '*':
            {
                return numberOne * numberTwo;
            }
            case '/':
            {
                if (numberTwo == 0)
                {
                    throw new DivideByZeroException("Не надо делить на 0");
                }
                return numberOne / numberTwo;
            }
            default:
            {
                throw new InvalidOperationException("Я не знаю, что произошло, но произошло что-то страшное");
            }
        }
    }
}

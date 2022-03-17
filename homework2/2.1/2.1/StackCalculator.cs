using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    public class StackCalculator
    {
        private static void PerformOperation(IStack stack, string symbol)
        {
            var operandOne = stack.Pop();
            var operandTwo = stack.Pop();
            if (symbol == "+")
            {
                stack.Push(operandOne + operandTwo);
            }
            else if (symbol == "-")
            {
                stack.Push(operandTwo - operandOne);
            }
            else if (symbol == "*")
            {
                stack.Push(operandTwo * operandOne);
            }
            else if (symbol == "/")
            {
                stack.Push(operandTwo / operandOne);
            }
        }
        public static double Calculate(string postfixExpression, IStack stack)
        {
            int number = 0;
            var strings = postfixExpression.Split();
            foreach (var element in strings)
            {
                if (int.TryParse(element, out number))
                {
                    stack.Push(number);
                    continue;
                }
                if (element == "")
                {
                    continue;
                }
                switch (element)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        {
                            if (stack.IsEmpty())
                            {
                                throw new InvalidOperationException("Ошибка");
                            }
                            double head = stack.Pop();
                            if (stack.IsEmpty())
                            {
                                throw new InvalidOperationException("Ошибка");
                            }
                            if (element == "/" && head.CompareTo(0) == 0)
                            {
                                throw new DivideByZeroException("Деление на ноль");
                            }
                            stack.Push(head);
                            PerformOperation(stack, element);
                            break;
                        }
                    default:
                        throw new InvalidOperationException("Ошибка");
                }
            }
            if (stack.IsEmpty())
            {
                throw new InvalidOperationException("Ошибка");
            }
            var result = stack.Pop();
            if (stack.IsEmpty())
            {
                return result;
            }
            throw new InvalidOperationException("Ошибка");
        }
    }
}
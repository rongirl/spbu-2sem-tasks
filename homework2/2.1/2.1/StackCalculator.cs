using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{  
    public class StackCalculator
    {
        private static void PerformOperation(IStack stack, char symbol)
        {
            var operandOne = stack.Pop();
            var operandTwo = stack.Pop();
            if (symbol == '+')
            {
                stack.Push(operandOne + operandTwo);
            }
            else if (symbol == '-')
            {
                stack.Push(operandTwo - operandOne);
            }
            else if (symbol == '*')
            {
                stack.Push(operandTwo * operandOne);
            }
            else if (symbol == '/')
            {
                stack.Push(operandTwo / operandOne);
            }
        }
        public static (bool, double) Calculate(string postfixExpression, IStack stack)
        {
            string number = "";
            for (int i = 0; i < postfixExpression.Length; i++)
            {   
                
                if (Char.IsDigit(postfixExpression[i]))
                {
                    number = string.Concat(number, char.ToString(postfixExpression[i]));
                    continue;
                }
                if (number.Length > 0)
                {
                    stack.Push(int.Parse(number));
                    number = "";
                    continue;
                }
                if (postfixExpression[i] == ' ')
                {
                    continue;
                }
                switch (postfixExpression[i])
                {   
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    {   
                        if (stack.IsEmpty())
                        {
                            return (false, 0);
                        }
                        double head = stack.Pop();
                        if (stack.IsEmpty() || (postfixExpression[i] == '/' && head.CompareTo(0) == 0))
                        {
                            return (false, 0);
                        }
                        stack.Push(head);
                        PerformOperation(stack, postfixExpression[i]);
                        break;
                    }
                    default:
                        return (false, 0);
                }
            }
            if (stack.IsEmpty())
            {
                return (false, 0);
            }
            var result = stack.Pop();
            if (stack.IsEmpty())
            {
                return (true, result);
            }
            return (false, 0);
        }
    }
}

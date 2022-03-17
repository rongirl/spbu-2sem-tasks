using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("0 - стек на массиве\n1 - стек на списке");
            var symbol = Console.ReadLine();
            if (symbol == null)
            {
                Console.WriteLine(":(");
                return;
            }
            if (!int.TryParse(symbol, out int number))
            {
                Console.WriteLine("Неверный ввод");
                return;
            }
            IStack stack;
            if (number == 0)
            {
                stack = new StackArray();
            }
            else if (number == 1)
            {
                stack = new StackList();
            }
            else
            {
                return;
            }
            Console.WriteLine("Введите выражение в постфиксной записи: ");
            var inputString = Console.ReadLine();
            if (inputString == null)
            {
                return;
            }
            Console.WriteLine("Результат вычисления: ");
            Console.WriteLine(StackCalculator.Calculate(inputString, stack));
        }
    }
}
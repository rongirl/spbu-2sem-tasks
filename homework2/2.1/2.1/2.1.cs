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
            var inputString = Console.ReadLine();
            if (inputString == null)
            {
                return;
            }
            IStack stack = new StackList();
            Console.WriteLine(StackCalculator.Calculate(inputString, stack));
        }
    }
}
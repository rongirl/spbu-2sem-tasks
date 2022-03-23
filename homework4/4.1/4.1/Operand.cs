using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1;

public class Operand : INode
{
    private int Value { get; set; }

    public void Print()
    {
        Console.Write($"{Value}");
    }

    public int Calculate() => Value;
}


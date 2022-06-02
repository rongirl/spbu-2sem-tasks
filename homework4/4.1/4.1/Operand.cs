using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1;

public class Operand : INode
{
    public int value { get; set; }

    public void Print()
    {
        Console.Write($"{value} ");
    }

    public int Calculate() => value;
}


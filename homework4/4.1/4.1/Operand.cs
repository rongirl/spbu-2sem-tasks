using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1;

public class Operand : INode
{
    public int value { get; set; }

    public void Print()
    {
        Console.Write($"{value} ");
    }

    public int Calculate() => value;
}


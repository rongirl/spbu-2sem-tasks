using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1;

public class Substraction : Operation
{
    public override int Calculate()
    {
        return leftSon.Calculate() - rightSon.Calculate();  
    }

    public override void Print()
    {   

        Console.Write("( -");
        base.Print();
        Console.Write(" ) ");
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1;
public abstract class Operation : INode
{
    public INode leftSon { get; set; }
    public INode rightSon { get; set; }

    public virtual void Print()
    {
        leftSon.Print();    
        rightSon.Print();   
    }

    public abstract int Calculate();
}


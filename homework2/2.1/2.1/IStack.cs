using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1;

public interface IStack
{
    void Push(double value);

    double Pop();

    bool IsEmpty();
}
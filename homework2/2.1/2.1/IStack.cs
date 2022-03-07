using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    internal interface IStack
    {
        void Push(int value);

        int Pop();

        bool IsEmpty();

        void DeleteStack();
    }
}

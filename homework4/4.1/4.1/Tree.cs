using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1;
public class Tree
{
    public int getNumber(string inputString, int index)
    {
        int number = 0;
        int sign = 1;
        if (inputString[index] == '-')
        {
            sign = -1;
            index++;
        }
        while (index < inputString.Length && inputString[index] >= '0' && inputString[index] <= '9')
        {
            index++;
            number = number * 10 + (int)inputString[index];
        }
        return number * sign;
    }
    public INode createNewNode()
}

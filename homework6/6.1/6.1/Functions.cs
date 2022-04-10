using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1;

public class Functions
{
    List<int>Map(List<int> list, Func<int, int> function)
    {
        List<int> result = new List<int>();
        foreach (var i in list)
        {
            result.Add(function(i));
        }
        return result;
    }

    List<int>Filter(List<int> list, Func<int, bool> function)
    {
        List<int> result = new List<int>();
        foreach (var i in list)
        {
            if (function(i))
            {
                result.Add(i);
            }
        }
        return result;
    }

    //int Fold
}

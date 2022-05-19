using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparing;

public class CompareInt: IComparer<int>
{
    public int Compare(int x, int y)
    {
        return x.CompareTo(y);
    }
}

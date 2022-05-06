using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1;
public class RouterTopology
{
    public Graph MakeTopology(string filePath)
    {
        Graph graph = new Graph(filePath);
        foreach (var node in graph.Nodes)
        {

        }
    }
}

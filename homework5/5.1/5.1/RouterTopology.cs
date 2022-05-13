using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1;
/// <summary>
/// Класс RouterTopology
/// с методом MakeTopology
/// </summary>
public class RouterTopology
{  
    /// <summary>
    /// Создание топологии
    /// </summary>
    /// <param name="filePathInput">Путь файла с исходным графом</param>
    /// <param name="filePathOutput">Путь файла с итоговым графом</param>
    public void MakeTopology(string filePathInput, string filePathOutput)
    {
        Graph graph = new Graph(filePathInput);
        graph.Nodes.Sort((a, b) => a.Item3.CompareTo(b.Item3));
        foreach (var node in graph.Nodes)
        {
            graph.DeleteEdge(node); 
            if (!graph.CheckConnectedness(node.Item1, node.Item2))
            {
                graph.Matrix[node.Item1, node.Item2] = node.Item3;
                graph.Matrix[node.Item2, node.Item1] = node.Item3;
            }
        }
        graph.PrintGraph(filePathOutput);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1;

public class Graph
{
    public List<Tuple<int, int, int>> Nodes { get; set; }
    public int CountNodes;
    public int CountEdges;
    public int[,] Matrix { get; set; }
    private int MatrixLength;
    private int MaxNumberNode;

    public Graph(string filePath)
    {
        Nodes = new List<Tuple<int, int, int>>();
        CountNodes = 0;
        MatrixLength = 20;
        CountEdges = 0;
        MaxNumberNode = 0;
        Matrix = new int[MatrixLength, MatrixLength];
        Parse(filePath);
    }

    private void Parse(string filePath)
    {
        using (StreamReader reader = new StreamReader("C:/Users/Acer/source/repos/spbu-2sem-tasks/homework5/5.1/5.1/Input.txt"))
        {
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();    
                string[] lineParts = line.Split(' ');
                int numberNode = int.Parse(lineParts[0].Split(':')[0]);
                MaxNumberNode = Math.Max(numberNode, MaxNumberNode);
                for (int i = 1; i < lineParts.Length; i += 2)
                {   
                    int currentNode = int.Parse(lineParts[i]);
                    MaxNumberNode = Math.Max(currentNode, MaxNumberNode);
                    if (currentNode >= MatrixLength || numberNode >= MatrixLength)
                    {
                        Resize();
                    }
                    CountNodes += 2;
                    CountEdges++;
                    int weightNode = int.Parse(lineParts[i+1].Split('(')[1].Split(")")[0]);
                    var node = new Tuple<int, int, int>(numberNode, currentNode, weightNode);
                    Nodes.Add(node);
                    Matrix[numberNode, currentNode] = weightNode;
                    Matrix[currentNode, numberNode] = weightNode;
                }
            }
        }
    }

    private void Resize()
    {
        MatrixLength *= 2;
        int[,] newMatrix = new int[MatrixLength, MatrixLength];
        for (int i = 0; i <= MaxNumberNode; i++)
        {
            for (int j = 0; j <= MaxNumberNode; j++)
            {
                newMatrix[i, j] = Matrix[i, j];
            }
        }
        Matrix = newMatrix;
    }

    public bool CheckConnectedness(int oneNode, int twoNode)
    {
        bool[] visited = new bool[MaxNumberNode + 1];
        return Dfs(oneNode, twoNode, ref visited);
    }

    private bool Dfs(int oneNode, int twoNode, ref bool[] visited)
    {
        if (oneNode == twoNode)
        {
            return true;
        }
        visited[oneNode] = true;    
        for (int i = 0; i <= MaxNumberNode; i++)
        {
            if (Matrix[oneNode, i] != 0)
            {
                if (!visited[i] && Dfs(i, twoNode, ref visited))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void DeleteEdge(Tuple<int, int, int> node)
    {
        Matrix[node.Item1, node.Item2] = 0;
        Matrix[node.Item2, node.Item1] = 0;
    }
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        graph.Parse("kkk");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1;

/// <summary>
/// Класс граф со списком его вершин,
/// с матрицей смежности,
/// с размером матрицы,
/// с максимальным номером вершины
/// </summary>
public class Graph
{
    /// <summary>
    /// Список вершин
    /// </summary>
    public List<Tuple<int, int, int>> Nodes { get; set; }

    /// <summary>
    /// Матрица смежности
    /// </summary>
    public int[,] Matrix { get; set; }

    /// <summary>
    /// Размер матрицы
    /// </summary>
    private int MatrixLength;

    /// <summary>
    /// Максимальный номер вершины
    /// </summary>
    private int MaxNumberNode;

    /// <summary>
    /// Инициализация графа
    /// </summary>
    /// <param name="filePath">Путь файла</param>
    public Graph(string filePath)
    {
        Nodes = new List<Tuple<int, int, int>>();
        MatrixLength = 20;
        MaxNumberNode = 0;
        Matrix = new int[MatrixLength, MatrixLength];
        Parse(filePath);
    }
    /// <summary>
    /// Функция, которая парсит файл
    /// и представляет его данные в виде графа
    /// </summary>
    /// <param name="filePath">Путь файла</param>
    private void Parse(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
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
                    int weightNode = int.Parse(lineParts[i+1].Split('(')[1].Split(")")[0]);
                    var node = new Tuple<int, int, int>(numberNode, currentNode, weightNode);
                    Nodes.Add(node);
                    Matrix[numberNode, currentNode] = weightNode;
                    Matrix[currentNode, numberNode] = weightNode;
                }
            }
        }
    }

    /// <summary>
    /// Функция увеличивает размер матрицы
    /// </summary>
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

    /// <summary>
    /// Проверяет связность от одной вершины 
    /// до другой
    /// </summary>
    /// <returns>Если вершины связаны, то 
    /// функция возвращает true,
    /// иначе false</returns>
    public bool CheckConnectedness(int oneNode, int twoNode)
    {
        bool[] visited = new bool[MaxNumberNode + 1];
        return Dfs(oneNode, twoNode, ref visited);
    }

    /// <summary>
    /// Поиск в глубину 
    /// </summary>
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

    /// <summary>
    /// Удаление ребра
    /// </summary>
    /// <param name="node">Вершина графа</param>
    public void DeleteEdge(Tuple<int, int, int> node)
    {
        Matrix[node.Item1, node.Item2] = 0;
        Matrix[node.Item2, node.Item1] = 0;
    }

    /// <summary>
    /// Распечатывание графа
    /// </summary>
    /// <param name="filepath">Путь файла</param>
    public void PrintGraph(string filepath)
    {   
        using StreamWriter writer = new StreamWriter(filepath);
        for (int i = 1; i <= MaxNumberNode; i++)
        {
            string line = "";
            bool visited = false;
            for (int j = i; j <= MaxNumberNode; j++)
            {
                if (Matrix[i, j] != 0)
                {
                    if (!visited)
                    {
                        line += i.ToString() + ":";
                        visited = true;
                    }
                    line += ($" {j.ToString()}({Matrix[i, j].ToString()})");
                }
            }
            if (line.Length != 0)
            {
                writer.WriteLine(line);
            }
        }

    }
    static void Main(string[] args)
    {
        
    }
}

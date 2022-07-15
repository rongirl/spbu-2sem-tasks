namespace Task4_1;

/// <summary>
/// Класс вершины дерева
/// </summary>
public class Operand : INode
{   
    /// <summary>
    /// Значение вершины
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Печатает вершину
    /// </summary>
    public void Print()
    {
        Console.Write($"{Value} ");
    }

    /// <summary>
    /// Вычисляет значение
    /// </summary>
    /// <returns>Значение вершины</returns>
    public int Calculate() => Value;
}
namespace Task4_1;

/// <summary>
/// Вершина в дереве разбора
/// </summary>
public interface INode
{
    /// <summary>
    /// Печатает вершину и поддерево
    /// </summary>
    void Print();

    /// <summary>
    /// Вычисляет значение поддерева
    /// </summary>
    /// <returns>Результат вычисления</returns>
    int Calculate();
}
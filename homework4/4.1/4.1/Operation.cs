namespace Task4_1;

/// <summary>
///  Класс вершины дерева
/// </summary>
public abstract class Operation : INode
{    
    /// <summary>
    /// Левый сын вершины
    /// </summary>
    public INode? LeftSon { get; set; }

    /// <summary>
    /// Правый сын вершины
    /// </summary>
    public INode? RightSon { get; set; }

    /// <summary>
    /// Печатает поддерево
    /// </summary>
    public virtual void Print()
    {
        LeftSon?.Print();    
        RightSon?.Print();   
    }

    /// <summary>
    /// Вычисляет значение поддерева
    /// </summary>
    /// <returns>Результат вычисления</returns>
    public abstract int Calculate();
}
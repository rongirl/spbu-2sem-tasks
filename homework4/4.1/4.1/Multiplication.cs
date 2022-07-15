namespace Task4_1;

/// <summary>
/// Операция умножения
/// </summary>
public class Multiplication : Operation
{
    /// <summary>
    /// Вычисляет значение поддерева
    /// </summary>
    /// <returns>Результат вычисления</returns>
    public override int Calculate()
    => LeftSon!.Calculate() * RightSon!.Calculate();

    /// <summary>
    /// Печатает операцию и поддерево
    /// </summary>
    public override void Print()
    {
        Console.Write("( * ");
        base.Print();
        Console.Write(" ) ");
    }
}
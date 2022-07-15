namespace Task4_1;

/// <summary>
/// Операция вычитания
/// </summary>
public class Subtraction : Operation
{
    /// <summary>
    /// Вычисляет значение поддерева
    /// </summary>
    /// <returns>Результат вычисления</returns>
    public override int Calculate()
    => LeftSon!.Calculate() - RightSon!.Calculate();

    /// <summary>
    /// Печатает операцию и поддерево
    /// </summary>
    public override void Print()
    {   
        Console.Write("( -");
        base.Print();
        Console.Write(" ) ");
    }
}
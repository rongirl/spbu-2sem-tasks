namespace Task4_1;

/// <summary>
/// Операция деления
/// </summary>
public class Division : Operation
{   
    /// <summary>
    /// Вычисляет значение поддерева
    /// </summary>
    /// <returns>Результат вычисления</returns>
    public override int Calculate()
    => LeftSon!.Calculate() / RightSon!.Calculate();

    /// <summary>
    /// Печатает операцию и поддерево
    /// </summary>
    public override void Print()
    {
        Console.Write("( /");
        base.Print();
        Console.Write(" ) ");
    }
}
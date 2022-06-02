namespace Task2_1;

/// <summary>
/// Класс, включающий в себя методы для
/// вычисления постфиксного выражения
/// </summary>
public static class StackCalculator
{   
    /// <summary>
    /// Добавление вычисления в стек
    /// </summary>
    /// <param name="stack">Стек</param>
    /// <param name="symbol">Постфиксная запись</param>
    private static void PerformOperation(IStack stack, string symbol)
    {
        var operandOne = stack.Pop();
        var operandTwo = stack.Pop();
        switch (symbol)
        {
            case "+":
            {
                stack.Push(operandOne + operandTwo);
                break;
            }
            case "-":
            {
                stack.Push(operandTwo - operandOne);
                break;
            }
            case "*":
            {
                stack.Push(operandTwo * operandOne);
                break;
            }
            case "/":
            {
                stack.Push(operandTwo / operandOne);
                break;
            }
            default:
            {
                throw new InvalidOperationException();
            }
        }
    }

    /// <summary>
    /// Вычисление значения постфиксной записи
    /// </summary>
    /// <param name="postfixExpression">Постфиксная запись выражения</param>
    /// <param name="stack">Стек</param>
    /// <returns>Значение выражения</returns>
    public static double Calculate(string postfixExpression, IStack stack)
    {
        int number = 0;
        var strings = postfixExpression.Split();
        foreach (var element in strings)
        {
            if (int.TryParse(element, out number))
            {
                stack.Push(number);
                continue;
            }
            if (element == "")
            {
                continue;
            }
            switch (element)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    {
                        if (stack.IsEmpty())
                        {
                            throw new InvalidOperationException("Ошибка");
                        }
                        double head = stack.Pop();
                        if (stack.IsEmpty())
                        {
                            throw new InvalidOperationException("Ошибка");
                        }
                        if (element == "/" && head.CompareTo(0) == 0)
                        {
                            throw new DivideByZeroException("Деление на ноль");
                        }
                        stack.Push(head);
                        PerformOperation(stack, element);
                        break;
                    }
                default:
                    throw new InvalidOperationException("Ошибка");
            }
        }
        if (stack.IsEmpty())
        {
            throw new InvalidOperationException("Ошибка");
        }
        var result = stack.Pop();
        if (stack.IsEmpty())
        {
            return result;
        }
        throw new InvalidOperationException("Ошибка");
    }
}
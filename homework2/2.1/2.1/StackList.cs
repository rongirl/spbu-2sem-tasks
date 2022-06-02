namespace Task2_1;

/// <summary>
/// Стек, основанный на списке
/// </summary>
public class StackList : IStack
{
    /// <summary>
    /// Верхний элемент стека
    /// </summary>
    private StackElement? head;

    /// <summary>
    /// Класс элемента из стека, 
    /// состоящий из значения элемента,
    /// ссылки на следующий элемент
    /// </summary>
    private class StackElement
    {
        public double value;
        public StackElement? next;
    }

    /// <summary>
    /// Проверка на пустоту
    /// </summary>
    /// <returns>True, если пуст
    /// False, если нет</returns>
    public bool IsEmpty()
        => head == null;

    /// <summary>
    /// Добавляет элемент в голову стека
    /// </summary>
    /// <param name="value">Добавляемое значение</param>
    public void Push(double value)
        => head = new StackElement { value = value, next = head };

    /// <summary>
    /// Возвращает значение с головы стека и удаляет его
    /// </summary>
    public double Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Стек пуст");
        }
        if (head == null)
        {
            throw new InvalidOperationException("Null");
        }
        double value = head.value;
        head = head.next;
        return value;
    }
}
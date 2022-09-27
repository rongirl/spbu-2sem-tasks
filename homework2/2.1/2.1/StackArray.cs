namespace Task2_1;

/// <summary>
/// Стек, основанный на массиве
/// </summary>
public class StackArray : IStack
{   
    /// <summary>
    /// Массив элементов
    /// </summary>
    private double[] stackElements;

    /// <summary>
    /// Размер стека
    /// </summary>
    private int size;

    /// <summary>
    /// Инициализация стека
    /// </summary>
    public StackArray()
    {
        stackElements = new double[10];
    }

    /// <summary>
    /// Добавляет элемент в голову стека
    /// </summary>
    /// <param name="value">Добавляемое значение</param>
    public void Push(double value)
    {
        if (size == stackElements.Length)
        {
            Resize();
        }
        stackElements[size] = value;
        size++;
    }

    /// <summary>
    /// Увеличение размера массива
    /// </summary>
    public void Resize()
    {
        Array.Resize(ref stackElements, stackElements.Length * 2);
    }

    /// <summary>
    /// Проверка на пустоту
    /// </summary>
    /// <returns>True, если пуст
    /// False, если нет</returns>
    public bool IsEmpty()
       => size == 0;

    /// <summary>
    /// Возвращает значение с головы стека и удаляет его
    /// </summary>
    public double Pop()
    {
        if (IsEmpty())
        {
            throw new Exception("Стек пуст");
        }
        size--;
        var headStack = stackElements[size];
        stackElements[size] = 0;
        return headStack;
    }
}
namespace Task2_1;

/// <summary>
/// Интерфейс для стека
/// </summary>
public interface IStack
{
    /// <summary>
    /// Добавляет элемент в голову стека
    /// </summary>
    /// <param name="value">Добавляемое значение</param>
    void Push(double value);

    /// <summary>
    /// Возвращает значение с головы стека и удаляет его
    /// </summary>
    double Pop();

    /// <summary>
    /// Проверяет стек на пустоту
    /// </summary>
    /// <returns>True, если пуст
    /// False, если нет</returns>
    bool IsEmpty();
}
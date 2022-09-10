using Task4_2.Exception;

namespace Task4_2;

/// <summary>
/// Список элементов, в котором значения не совпадают
/// </summary>
public class UniqueList : List
{
    /// <summary>
    /// Добавление элемента, значение которого нет в списке, по позиции в список
    /// </summary>
    /// <param name="value">Значение элемента</param>
    /// <param name="position">Номер позиции добавляемого элемента, позиции с нуля</param>
    /// <exception cref="AddException">Выбрасываемое исключение, когда значение уже присутствует в списке</exception>
    public override void Add(int value, int position)
    {
        if (Contain(value))
        {
            throw new AddException();
        }
        base.Add(value, position);
    }

    /// <summary>
    /// Изменение значения 
    /// </summary>
    /// <param name="value">Значение</param>
    /// <param name="position">Позиция</param>
    public override void ChangeValue(int value, int position)
    {
        if (Contain(value))
        {
            if (PositionOf(value) == position)
            {
                return;
            }
            throw new AddException();   
        }
        base.ChangeValue(value, position);
    }
}
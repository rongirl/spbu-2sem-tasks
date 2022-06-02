using Task4_2.Exception;

namespace Task4_2;

/// <summary>
/// Список элементов
/// </summary>
public class List
{
    /// <summary>
    /// Элемент списка, содержит в себе значение и ссылку на следующий элемент
    /// </summary>
    private class ListElement
    {
        public ListElement(int value, ListElement next)
        {
            Value = value;
            Next = next;
        }

        public ListElement Next { get; set; }
        public int Value { get; set; }
    }
    private ListElement head;

    /// <summary>
    /// Количество элементов в списке
    /// </summary>
    private int size = 0;

    /// <summary>
    /// Добавление элемента в список по позиции
    /// </summary>
    /// <param name="value">Значение элемента добавляемого в список</param>
    /// <param name="position">Номер позиции добавляемого элемента, позиции с нуля</param>
    /// <exception cref="InvalidPositionException">Выбрасываемое исключение, когда позиция недопустима</exception>
    public virtual void Add(int value, int position)
    {
        if (position > size || position < 0)
        {
            throw new InvalidPositionException();
        }
        ListElement current = head;
        ListElement previous = null;
        for (int i = 0; i < position; i++)
        {
            previous = current;
            current = current.Next;
        }
        if (previous == null)
        {   
            head = new ListElement(value, head);
        }
        else
        {
            previous.Next = new ListElement(value, current);
        }
        size++;
    }

    /// <summary>
    /// Удаление элемента по его позиции
    /// </summary>
    /// <param name="position">Позиция удаляемого элемента</param>
    /// <exception cref="InvalidPositionException">Выбрасываемое исключение, когда позиция недопустима</exception>
    public void Remove(int position)
    {
        if (position >= size || position < 0)
        {
            throw new InvalidPositionException();
        }
        ListElement current = head;
        ListElement previous = null;
        for (int i = 0; i < position; i++)
        {
            previous = current;
            current = current.Next;
        }
        if (previous == null)
        {
            head = current.Next;
        }
        else
        {
            previous.Next = current.Next;
        }
        size--;
    }

    /// <summary>
    /// Изменение значения элемента
    /// </summary>
    /// <param name="value">Новое значение</param>
    /// <param name="position">Позиия элемента, значение которого будет изменено</param>
    /// <exception cref="InvalidPositionException">Выбрасываемое исключение, когда позиция недопустима</exception>
    public virtual void ChangeValue(int value, int position)
    {
        if (position >= size || position < 0)
        {
            throw new InvalidPositionException();
        }
        ListElement current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.Next;
        }
        current.Value = value;
    }

    /// <summary>
    /// Функция проверяет содержится ли значение в списке
    /// </summary>
    /// <param name="value">Значение, проверяемое на наличие в списке</param>
    /// <returns>True, если значение есть в списке; false, если значение отсутствует</returns>
    public bool Contain(int value)
    {   
        ListElement current = head; 
        for (int i = 0; i < size; i++)
        {
            if (current.Value == value)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    } 

    /// <summary>
    /// Взятие позиции элемента в списке
    /// </summary>
    /// <param name="value">Значение</param>
    /// <returns>Возвращает позицию</returns>
    public int PositionOf(int value)
    {
        var current = head;
        int i = -1;
        while (current != null)
        {
            if (current.Value == value)
            {
                i++;
                return i;
            }
            current = current.Next;
        }
        return i;
    }
}
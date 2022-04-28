namespace Task;

public class Queue
{   
    /// <summary>
    /// Элемент очереди, хранит в себе значение,
    /// численный приоритет, ссылку на следующий элемент
    /// </summary>
    private class QueueElement
    {
        public QueueElement(object value, int priority, QueueElement next)
        {
            Value = value;
            Next = next;
            Priority = priority;    
        }
        public QueueElement Next { get; set; }
        public object Value { get; set; }
        public int Priority { get; set; }   
    }

    /// <summary>
    /// Первый элемент в очереди
    /// </summary>
    private QueueElement head;

    /// <summary>
    /// Добавление элемента в очередь по приоритету
    /// </summary>
    /// <param name="value">Значение элемента</param>
    /// <param name="priority">Численный приоритет элемента</param>
    public void Enqueue(object value, int priority)
    {
        if (IsEmpty())
        {
            head = new QueueElement(value, priority, head);
            return;
        }
        var current = head;
        QueueElement previous = null;
        while (current != null && current.Priority >= priority)
        {
            previous = current; 
            current = current.Next;
        }
        QueueElement newElement = new QueueElement(value, priority, current);  
        if (previous == null)
        {
            head = newElement;
            return;
        }
        previous.Next = newElement; 
    }

    /// <summary>
    /// Проверка на пустоту очереди
    /// </summary>
    /// <returns>True, если очередь пуста, false, если нет</returns>
    public bool IsEmpty() 
        => head == null;  

    /// <summary>
    /// Возвращает значение первого элемента по приоритету
    /// и удаляет его
    /// </summary>
    /// <returns>Значение первого элемента по приоритету</returns>
    /// <exception cref="Exception">Выбрасывается, если очередь пуста</exception>
    public object Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Очередь пуста");
        }
        var value = head.Value;
        head = head.Next;
        return value;
    }

    /// <summary>
    /// Проверяет содержится ли значение в очереди
    /// </summary>
    /// <param name="value">Исходное значение</param>
    /// <returns>True, если очередь содержится, false, если нет</returns>
    public bool IsContain(object value)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value == value)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public object GetHeadValue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();  
        }
        return head.Value;
    }

    public int GetHeadPriority()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();
        }
        return head.Priority;
    }

    static void Main(string[] args)
    {
        Queue queue = new Queue();
        queue.Enqueue("a", 5);
        queue.Enqueue("b", 5);
        queue.Enqueue("c", 1000);
        queue.Dequeue();    
    }

}


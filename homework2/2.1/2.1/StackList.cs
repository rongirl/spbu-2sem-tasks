namespace Task2_1;

public class StackList : IStack
{
    private StackElement? head;
    private class StackElement
    {
        public double value;
        public StackElement? next;
    }
    public bool IsEmpty()
        => head == null;    

    public void Push(double value)
        => head = new StackElement { value = value, next = head };

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
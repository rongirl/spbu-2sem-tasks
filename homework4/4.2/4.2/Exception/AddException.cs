namespace Task4_2.Exception;

/// <summary>
/// Выбрасываемое исключение, когда элемент уже присутствует в списке
/// </summary>
[System.Serializable]
public class AddException : System.Exception
{
    public AddException() { }
    public AddException(string message) : base(message) { }
    public AddException(string message, System.Exception inner) : base(message, inner) { }
    protected AddException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

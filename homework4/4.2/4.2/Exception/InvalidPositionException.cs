namespace Task4_2.Exception;

/// <summary>
/// Выбрасываемое исключение, когда позиция недопустима
/// </summary>
[System.Serializable]
public class InvalidPositionException : System.Exception
{
    public InvalidPositionException() { }
    public InvalidPositionException(string message) : base(message) { }
    public InvalidPositionException(string message, System.Exception inner) : base(message, inner) { }
    protected InvalidPositionException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

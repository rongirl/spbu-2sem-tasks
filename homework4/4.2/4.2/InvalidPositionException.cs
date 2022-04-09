using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2.Exception;
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

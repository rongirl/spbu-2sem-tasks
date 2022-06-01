namespace BurrowsWheelerTransform;

/// <summary>
/// Класс выполняет прямое и обратное преобразование 
/// Барроуза-Уиллера
/// </summary>
class Program
{   
    /// <summary>
    /// Прямое преобразование Барроуза-Уиллера
    /// </summary>
    /// <param name="originalString">Строка, над которой происходит прямое преобразование</param>
    private static (string, int) BurrowsWheelerTransform(string originalString)
    {
        int index = 0;
        var tableOfStrings = new string[originalString.Length];
        for (int i = 0; i < originalString.Length; i++)
        {
            tableOfStrings[i] = originalString;
            char symbol = originalString[originalString.Length - 1];
            originalString = originalString.Remove(originalString.Length - 1, 1);
            originalString = symbol + originalString;
        }
        Array.Sort(tableOfStrings);
        string resultString = "";
        for (int i = 0; i < tableOfStrings.Length; i++)
        {
            resultString += tableOfStrings[i][originalString.Length - 1];
            if (string.Compare(tableOfStrings[i], originalString) == 0)
            {
                index = i;
            }
        }
        return (resultString, index);
    }

    /// <summary>
    /// Обратное преобразование 
    /// Барроуза-Уиллера
    /// </summary>
    /// <param name="resultString">Строка, над которой происходит обратное преобразование</param>
    /// <param name="index">Индекс конца строки, полученный из прямого преобразования</param>
    /// <returns></returns>
    private static string InverseBurrowsWheelerTransform(string resultString, int index)
    {
        var tableOfString = new string[resultString.Length];
        for (int i = 0; i < tableOfString.Length; i++)
        {
            for (int j = 0; j < tableOfString.Length; j++)
            {
                tableOfString[j] = resultString[j] + tableOfString[j];
            }
            Array.Sort(tableOfString);
        }
        return tableOfString[index];
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите исходную строку: ");
        var inputString = Console.ReadLine();
        if (inputString == null)
        {
            return;
        }
        Console.WriteLine("Строка после прямого преобразования: ");
        var (stringAfterDirectTransform, index) = BurrowsWheelerTransform(inputString);
        Console.WriteLine($"{stringAfterDirectTransform}, {index}");
        Console.WriteLine("Строка после обратного преобразования: ");
        Console.WriteLine(InverseBurrowsWheelerTransform(stringAfterDirectTransform, index));
    }
}
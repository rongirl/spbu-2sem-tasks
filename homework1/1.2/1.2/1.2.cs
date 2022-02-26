using System;

namespace BurrowsWheelerTransform
{
    class Program
    {
        private static string BurrowsWheelerTransform(string originalString, ref int index)
        {
            string[] tableOfStrings = new string[originalString.Length];
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
            return resultString;
        }
        private static string InverseBurrowsWheelerTransform(string resultString, int index)
        {
            string[] tableOfString = new string[resultString.Length];
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
            int number = 0;
            Console.WriteLine("Введите исходную строку: ");
            var inputString = Console.ReadLine();
            if (inputString == null)
            {
                return;
            }
            Console.WriteLine("Строка после прямого преобразования: ");
            string stringAfterDirectTransform = BurrowsWheelerTransform(inputString, ref number);
            Console.WriteLine(stringAfterDirectTransform, number);
            Console.WriteLine("Строка после обратного преобразования: ");
            Console.WriteLine(InverseBurrowsWheelerTransform(stringAfterDirectTransform, number));
        }
    }
}

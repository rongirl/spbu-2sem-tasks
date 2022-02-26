using System;

namespace BurrowsWheelerTransform
{
    class Program
    {
        private static string BurrowsWheelerTransform(string originalString, ref int number)
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
                    number = i;
                }
            }
            return resultString;
        }
        static void Main(string[] args)
        {
            int number = 0;
            Console.WriteLine("{0} {1}", BurrowsWheelerTransform("abcdef", ref number), number);
            //Console.WriteLine(number);
        }
    }
}

namespace Sort
{
    public class SortClass
    { 
        public static int[] BubbleSort(int[] array)
        {
            int temporary;
            for (int i = 0; i < array.Length; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temporary = array[i];
                        array[i] = array[j];
                        array[j] = temporary;
                    }
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов массива:");
            var inputString = Console.ReadLine();
            if (inputString == null)
            {
                return;
            }
            int countOfElements = int.Parse(inputString);
            int[] array = new int[countOfElements]; 
            Console.WriteLine("Введите элементы массива:");
            var numbers = Console.ReadLine().Split(new[] { " ", " ", " "}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(numbers[i]);
            }
            BubbleSort(array);
            Console.WriteLine("После сортировки:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ",array[i]);
            }
        }
    }
}


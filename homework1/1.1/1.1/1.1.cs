namespace Sort;

public static class Sort
{ 
    public static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for(int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите массив чисел: ");
        var strings = Console.ReadLine()?.Split();
        if (strings == null)
        {
            return;
        }
        int[] array = Array.ConvertAll(strings, int.Parse);
        BubbleSort(array);
        Console.WriteLine("После сортировки:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
    }
}


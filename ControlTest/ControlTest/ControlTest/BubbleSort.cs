using System.Collections.Generic;
namespace Sorting;

public class Sort
{
    /// <summary>
    /// BubbleSort
    /// </summary>
    /// <param name="list">Список из элементов любого типа данных</param>
    /// <param name="comparer">Объект, сравнивающий элементы</param>
    public static void BubbleSort<T>(IList<T> list, IComparer<T> comparer)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
        }
    }

    static void Main(string[] args)
    {

    }
}



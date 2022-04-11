using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_1;

public class Functions
{
    /// <summary>
    /// Функция принимает список и функцию, преобразующую элементы списка
    /// </summary>
    /// <param name="list">Исходный список</param>
    /// <param name="function">Функция преобразования элементов исходного списка</param>
    /// <returns>Список элементов после преобразований</returns>
    public static List<int>Map(List<int> list, Func<int, int> function)
    {
        List<int> result = new List<int>();
        foreach (var element in list)
        {
            result.Add(function(element));
        }
        return result;
    }
    /// <summary>
    /// Функция создает новый список из элементов,
    /// для которых переданная функция возвращает true
    /// </summary>
    /// <param name="list">Исходный список</param>
    /// <param name="function">Переданная функция</param>
    /// <returns>Список элементов, для которых переданная функция возвратила true</returns>
    public static List<int>Filter(List<int> list, Func<int, bool> function)
    {
        List<int> result = new List<int>();
        foreach (var element in list)
        {
            if (function(element))
            {
                result.Add(element);
            }
        }
        return result;
    }
    /// <summary>
    /// Функция накапливает значение при прохождении списка
    /// </summary>
    /// <param name="list">Исходный список</param>
    /// <param name="start">Начальное значение</param>
    /// <param name="function"> Функция,которая берёт текущее накопленное значение и текущий элемент списка,
    ///и возвращает следующее накопленное значение</param>
    /// <returns>Накопленное значение</returns>
    public static int Fold(List<int> list, int start, Func<int, int, int> function)
    {
        foreach (var element in list)
        {
            start = function(start, element);
        }
        return start;
    }
}

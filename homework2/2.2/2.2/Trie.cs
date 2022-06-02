namespace TrieSpace;

/// <summary>
/// Бор
/// </summary>
public class Trie
{
    /// <summary>
    /// Узел бора, включающая в себя 
    /// словарь вершин, переменную, обозначающую 
    /// является ли вершина листом,
    /// количество строк включающих префикс
    /// </summary>
    private class Node
    {
        public Dictionary<char, Node> next = new();
        public bool isTerminal;
        public int countStringsContainPrefix = 0;
    }

    /// <summary>
    /// Размер бора
    /// </summary>
    private int size = 0;

    /// <summary>
    /// Корневой узел бора
    /// </summary>
    private Node root = new();

    /// <summary>
    /// Добавление строки в бор
    /// </summary>
    /// <param name="element">Добавляемая строка</param>
    /// <returns>True, если строка добавилась
    /// False, если уже была в боре</returns>
    public bool Add(string element)
    {
        if (Contain(element))
        {
            return false;
        }
        Node current = root;
        for (int i = 0; i < element.Length; i++)
        {
            if (current == null)
            {
                return false;
            }
            char symbol = element[i];
            if (current != null && !current.next.ContainsKey(symbol))
            {
                current.next.Add(symbol, new Node());
            }
            if (current != null && current.next.ContainsKey(symbol))
            {
                current = current.next[symbol];
                current.countStringsContainPrefix++;
            }
        }
        if (current != null)
        {
            current.isTerminal = true;
        }
        size++;
        return true;
    }

    /// <summary>
    /// Проверка на присутствие строки в боре
    /// </summary>
    /// <param name="element">Строка</param>
    /// <returns>True, если присутствует
    /// False, если отсутствует </returns>
    public bool Contain(string element)
    {
        Node current = root;
        for (int i = 0; i < element.Length; i++)
        {
            if (!current.next.ContainsKey(element[i]))
            {
                return false;
            }
            current = current.next[element[i]];
            if (current == null)
            {
                return false;
            }
        }
        return current.isTerminal;
    }

    /// <summary>
    /// Удаление строки
    /// </summary>
    /// <param name="element">Строка</param>
    /// <returns>True, если строка удалена
    /// False, если строки не было в боре</returns>
    public bool Remove(string element)
    {
        if (!Contain(element))
        {
            return false;
        }
        Node current = root;
        for (int i = 0; i < element.Length; i++)
        {
            if (current == null)
            {
                return false;
            }
            char symbol = element[i];
            if (current.next[symbol] == null)
            {
                return false;
            }
            if (current.next[symbol].countStringsContainPrefix > 1)
            {
                current.next[symbol].countStringsContainPrefix--;
                current = current.next[symbol];
            }
            else
            {
                var temporary = current.next[symbol];
                current.next[symbol] = null!;
                current.next.Remove(symbol);
                current = temporary;
            }
        }
        size--;
        return true;
    }

    /// <summary>
    /// Функция считает количество элементов,
    /// которые начинаются с определенного префикса
    /// </summary>
    /// <param name="prefix">Префикс</param>
    /// <returns>Количество элементов</returns>

    public int HowManyStartsWithPrefix(string prefix)
    {
        Node current = root;
        for (int i = 0; i < prefix.Length; i++)
        {
            var symbol = prefix[i];
            if (current != null && current.next.ContainsKey(symbol))
            {
                current = current.next[symbol];
            }
            else
            {
                return 0;
            }
        }
        return current.countStringsContainPrefix;
    }

    /// <summary>
    /// Размер бора
    /// </summary>
    /// <returns></returns>
    public int Size()
        => size;
}

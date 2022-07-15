namespace Task4_1;

/// <summary>
/// Дерево разбора
/// </summary>
public class Tree
{   
    /// <summary>
    /// Корень дерева
    /// </summary>
    private INode? root;
    
    /// <summary>
    /// Инициализация экземпляра класса
    /// </summary>
    /// <param name="inputString">Префиксная запись выражения</param>
    public Tree(string inputString)
    {
        MakeTree(inputString);  
    }

    /// <summary>
    /// Создает новую вершину дерева
    /// </summary>
    /// <param name="strings">Массив подстрок префиксной записи</param>
    /// <param name="index">Индекс подстроки</param>
    /// <returns>Новая вершина</returns>
    private INode CreateNewNode(string[] strings, ref int index)
    {
        index++;
        int operand = 0;
        if (int.TryParse(strings[index], out operand))
        {
            return new Operand() { Value = operand };
        }
        Operation newNode; 
        switch (strings[index])
        { 
            case "+":
            {
                newNode = new Addition();
                break;
            }
            case "*":
            {
                newNode = new Multiplication();
                break;
            }
            case "-":
            {
                newNode = new Subtraction();
                break;
            }
            case "/":
            {
                newNode = new Division();
                break;
            }
            default:
                throw new InvalidOperationException();
        }
        newNode.LeftSon = CreateNewNode(strings, ref index);    
        newNode.RightSon = CreateNewNode(strings, ref index);
        return newNode;
    }

    /// <summary>
    /// Строит дерево разбора
    /// </summary>
    /// <param name="inputString">Префиксная запись выражения</param>
    public void MakeTree(string inputString)
    {
        int index = -1;
        var substrings = inputString.Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        root = CreateNewNode(substrings, ref index);
    }
    
    /// <summary>
    /// Печатает дерево
    /// </summary>
    public void Print() => root?.Print();

    /// <summary>
    /// Вычисляет значение выражения по дереву разбора
    /// </summary>
    /// <returns>Значение выражения</returns>
    public int Calculate() => root!.Calculate();
}
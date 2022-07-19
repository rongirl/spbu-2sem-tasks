namespace Task7_1;

/// <summary>
/// Класс, выполняющий операции с двумя числами
/// </summary>
public class Calculator
{
    /// <summary>
    /// Первое операнд
    /// </summary>
    private double? numberOne;

    /// <summary>
    /// Второ1 операнд
    /// </summary>
    private double? numberTwo;

    /// <summary>
    /// Операция
    /// </summary>
    private char? operation;

    /// <summary>
    /// Добавление операнда
    /// Если первый операнд существует, то
    /// добавляет или изменяет второй.
    /// Если первого операнда нет, то 
    /// добавляет первый операнд
    /// </summary>
    /// <param name="number">Добавляемое число</param>
    public void AddNumber(double number)
    {
        if (numberOne == null)
        {
            numberOne = number;
            return;
        }
        numberTwo = number;
    }

    /// <summary>
    /// Добавление операции
    /// </summary>
    /// <param name="operation">Добавляемая операция</param>
    public void AddOperation(char operation) => this.operation = operation;

    /// <summary>
    /// Удаление операции и операндов
    /// </summary>
    public void Clear()
    {
        numberOne = null;
        numberTwo = null;
        operation = null;
    }

    /// <summary>
    /// Вычисление выражения
    /// </summary>
    /// <returns>Результат вычисления</returns>
    public double? Calculate()
    {
        if (numberTwo == null || numberOne == null)
        {
            throw new InvalidOperationException();
        }
        switch (operation)
        {
            case '+':
            {
                return numberOne + numberTwo;
            }
            case '-':
            {                    
                return numberOne - numberTwo;
            }
            case '*':
            {
                return numberOne * numberTwo;
            }
            case '/':
            {
                if (numberTwo == 0)
                {
                    throw new DivideByZeroException("Не надо делить на 0");
                }
                return numberOne / numberTwo;
            }
            default:
            {
                throw new InvalidOperationException("Я не знаю, что произошло, но произошло что-то страшное");
            }
        }
    }
}
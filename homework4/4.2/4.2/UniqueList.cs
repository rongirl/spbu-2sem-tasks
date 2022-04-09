using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4._2.Exception;

namespace _4._2;

public class UniqueList : List
{
    /// <summary>
    /// Добавление элемента, значение которого нет в списке, по позиции в список
    /// </summary>
    /// <param name="value">Значение элемента</param>
    /// <param name="position">Номер позиции добавляемого элемента, позиции с нуля</param>
    /// <exception cref="AddException">Выбрасываемое исключение, когда значение уже присутствует в списке</exception>
    public void Add(int value, int position)
    {
        if (Contain(value))
        {
            throw new AddException();
        }
        base.Add(value, position);
    }
}

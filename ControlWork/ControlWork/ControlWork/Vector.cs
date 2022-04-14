using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork;
public class Vector
{
    private Dictionary<int, int> dictionary { get; set; }
    private int length;

    private int getNumber(string inputString, ref int index)
    {
        int number = 0;
        int sign = 1;
        if (inputString[index] == '-')
        {
            sign = -1;
            index++;
        }
        while (index < inputString.Length && inputString[index] > '0' && inputString[index] <= '9')
        {
            number = number * 10 + (inputString[index] - '0');
            index++;
        }
        return number * sign;
    }
    public Vector Inital(string vectorString)
    {   
        Vector vector  = new Vector();
        int index = 0;
        for (int i = 0; i < vectorString.Length; i++)
        {   
            if (vectorString[i] == ' ')
            {
                index++;
            }
            vector.dictionary.Add(index, getNumber(vectorString, ref i));
        }
        vector.length = index + 1;
        return vector;
    }
    public Vector Addition(Vector oneVector, Vector twoVector)
    {
        if (oneVector.length != twoVector.length)
        {
            throw new ArgumentException("((");
        }
        Vector resultVector = new Vector();   
        foreach(var item in oneVector.dictionary.Keys)
        {
            int result = 0;
            if (twoVector.dictionary.ContainsKey(item))
            {
                result = twoVector.dictionary[item] + oneVector.dictionary[item];
            }
            else
            {
                result = oneVector.dictionary[item];
            }
            resultVector.dictionary.Add(item, result);
        }
        foreach (var item in twoVector.dictionary.Keys)
        {
            int result = 0;
            if (oneVector.dictionary.ContainsKey(item))
            {
                result = twoVector.dictionary[item] + oneVector.dictionary[item];
            }
            else
            {
                result = twoVector.dictionary[item];
            }
            resultVector.dictionary.Add(item, result);
        }
        return resultVector;
    }

    public Vector Subtraction(Vector oneVector, Vector twoVector)
    {
        if (oneVector.length != twoVector.length)
        {
            throw new ArgumentException("((");
        }
        Vector resultVector = new Vector();
        foreach (var item in oneVector.dictionary.Keys)
        {
            int result = 0;
            if (twoVector.dictionary.ContainsKey(item))
            {
                result = oneVector.dictionary[item] - twoVector.dictionary[item];
            }
            else
            {
                result = oneVector.dictionary[item];
            }
            resultVector.dictionary.Add(item, result);
        }
        foreach (var item in twoVector.dictionary.Keys)
        {
            int result = 0;
            if (oneVector.dictionary.ContainsKey(item))
            {
                result = oneVector.dictionary[item] - twoVector.dictionary[item];
            }
            else
            {
                result -= twoVector.dictionary[item];
            }
            resultVector.dictionary.Add(item, result);
        }
        return resultVector;
    }

   public int ScalarProduct(Vector oneVector, Vector twoVector)
    {   
        if (oneVector.length != twoVector.length)
        {
            throw new ArgumentException("((");
        }
        int result = 0;
        foreach(var item in oneVector.dictionary.Keys)
        {
            if (twoVector.dictionary.ContainsKey(item))
            {
                result += twoVector.dictionary[item] * oneVector.dictionary[item];
            }
        }
        return result;
    }

    bool isNullVector(Vector vector)
    {
        return vector.dictionary.Count == 0;
    }
    static void Main(string[] args)
    {
        
    }
}


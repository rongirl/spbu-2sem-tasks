using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1;
public class Tree
{
    private INode root;
    public int getNumber(string inputString, ref int index)
    {
        int number = 0;
        int sign = 1;
        if (inputString[index] == '-')
        {
            sign = -1;
            index++;
        }
        while (index < inputString.Length && inputString[index] >= '0' && inputString[index] <= '9')
        {
            number = number * 10 + (inputString[index] - '0');
            index++;
        }
        return number * sign;
    }
    public INode createNewNode(string inputString, ref int index)
    {
        index++;
        Operation newNode;
        while (index < inputString.Length && (inputString[index] == '(' || inputString[index] == ' ' || inputString[index] == ')'))
        {
            index++;
        }
        if (inputString[index] == '+')
        {
            newNode = new Addition();
            newNode.leftSon = createNewNode(inputString, ref index);
            newNode.rightSon = createNewNode(inputString, ref index);
        }
        else if (inputString[index] == '-' && inputString[index + 1] == ' ')
        {
            newNode = new Substraction();
            newNode.leftSon = createNewNode(inputString, ref index);
            newNode.rightSon = createNewNode(inputString, ref index);
        }
        else if (inputString[index] == '*')
        {
            newNode = new Multiplication();
            newNode.leftSon = createNewNode(inputString, ref index);
            newNode.rightSon = createNewNode(inputString, ref index);
        }
        else if (inputString[index] == '/')
        {
            newNode = new Division();
            newNode.leftSon = createNewNode(inputString, ref index);
            newNode.rightSon = createNewNode(inputString, ref index);
        }
        else
        {
            Operand newNodeOperand = new Operand { value = getNumber(inputString, ref index) };
            return newNodeOperand;
        }
        return newNode;
    }
    
    public INode makeTree(string inputString)
    {
        int index = -1;
        root = createNewNode(inputString, ref index);
        return root;
    }

    public void Print() => root.Print();

    public int Calculate() => root.Calculate();
}

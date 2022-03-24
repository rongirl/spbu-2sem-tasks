using System;
using _4._1;

namespace Program;

class Program
{
    static void Main(string[] args)
    {
        string inputString = Console.ReadLine();
        Tree tree = new Tree();
        tree.makeTree(inputString);
        tree.Calculate();
        tree.Print();
    }
}
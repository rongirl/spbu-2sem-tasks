using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_2;

public class Game
{
    public List<List<char>> walls;
    public (int left, int top) Position { get; set; } = (-1, -1);

    public void LoadMap(string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            int numberOfString = Console.CursorTop;
            while (!reader.EndOfStream)
            {
                string inputString = reader.ReadLine();
                walls.Add(new List<char>());
                for (int i = Console.CursorLeft; i < inputString.Length;i++)
                {
                    if (inputString[i] == '@')
                    {
                        if (Position != (-1,-1))
                        {
                            throw new Exception("Ошибка");
                        }
                        Position = (i, numberOfString);
                    }
                    walls[numberOfString].Add(inputString[i]);
                }
                numberOfString++;   
            }
        }
    }

    public void PrintMap(string path)
    {
        walls = new List<List<char>>();
        LoadMap(path);
        foreach (var line in walls)
        {
            foreach (var symbol in line)
            {
                if (symbol == '@')
                {
                    Console.SetCursorPosition(Position.left, Position.top);
                }
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(Position.left, Position.top);
    }

    public void OnLeft(object sender, EventArgs args)
    {
        if (walls[Position.top][Position.left - 1] != ' ')
        {
            return;
        }
        Console.Write(' ');
        walls[Position.top][Position.left] = ' ';
        Console.SetCursorPosition(Position.left - 1, Position.top);
        Position = (Position.left - 1, Position.top);
        Console.Write('@');
        Console.SetCursorPosition(Position.left, Position.top);
        }

    public void OnRight(object sender, EventArgs args)
    {
        if (walls[Position.top][Position.left + 1] != ' ')
        {
            return;
        }
        Console.Write(' ');
        walls[Position.top][Position.left] = ' ';
        Console.SetCursorPosition(Position.left + 1, Position.top);
        Position = (Position.left + 1, Position.top);
        Console.Write('@');
        Console.SetCursorPosition(Position.left, Position.top);
    }

    public void OnDown(object sender, EventArgs args)
    {
        if (walls[Position.top + 1][Position.left] != ' ')
        {
            return;
        }
        Console.Write(' ');
        walls[Position.top][Position.left] = ' ';
        Console.SetCursorPosition(Position.left, Position.top + 1);
        Position = (Position.left, Position.top + 1);
        Console.Write('@');
        Console.SetCursorPosition(Position.left, Position.top);
    }

    public void OnUp(object sender, EventArgs args)
    {
        if (walls[Position.top - 1][Position.left] != ' ')
        {
            return;
        }
        Console.Write(' ');
        walls[Position.top][Position.left] = ' ';
        Console.SetCursorPosition(Position.left, Position.top - 1);
        Position = (Position.left, Position.top - 1);
        Console.Write('@');
        Console.SetCursorPosition(Position.left, Position.top);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_2;

public class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        try
        {
            var eventLoop = new EventLoop();
            var game = new Game("m.txt");

            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.Up;
            eventLoop.DownHandler += game.Down;

            eventLoop.Run();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Map file not found");
        }
    }
}

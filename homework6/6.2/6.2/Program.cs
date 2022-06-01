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
        try
        {
            var eventLoop = new EventLoop();
            Game game = new Game();
            game.PrintMap("map.txt");
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;

            eventLoop.Run();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
        }

    }
}

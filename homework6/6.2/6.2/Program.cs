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
            game.PrintMap("C:/Users/Acer/source/repos/spbu-2sem-tasks/homework6/6.2/6.2/map.txt");
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

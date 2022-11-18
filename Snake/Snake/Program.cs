using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static int MapWidth = 60;
        static int MapHeight = 20;
        static ConsoleColor color = ConsoleColor.Yellow;
        static ConsoleColor colorheadsnake = ConsoleColor.Blue;
        static ConsoleColor colorbodysnake = ConsoleColor.Green;
        static Dictionary dictionary = Dictionary.Right;
        static void Main(string[] args)
        {
            Console.SetWindowSize(MapWidth+1, MapHeight+1);
            Console.SetBufferSize(MapWidth+1,MapHeight+1);
            Console.CursorVisible = false;
            while (true)
            {
                StartGame();
                Console.SetCursorPosition(MapWidth / 3, MapHeight / 2);
                Console.WriteLine("Конец Игры!");
                Console.ReadKey(true);
                Console.Clear();
                break;
            }
        }
     
        static void StartGame()
        {
            BorderDraw();
            Snake s = new(MapWidth / 2, MapHeight / 2, colorheadsnake, colorbodysnake);
            while (true)
            {
                dictionary = SnakeControl(dictionary);
                s.Move(dictionary);
                Thread.Sleep(200);
                if (s.Head.X == MapWidth - 1 || s.Head.X == 0 || s.Head.Y == MapHeight - 1 || s.Head.Y == 0 || s.Any()) break;
            }
        }
        static void BorderDraw()
        {
            for (int i = 0; i <= MapWidth; i++)
            {
                new Pixel(i, 0, color).Draw();
                new Pixel(i, MapHeight, color).Draw();
            }
            for (int i = 0; i < MapHeight; i++)
            {
                new Pixel(0, i, color).Draw();
                new Pixel(MapWidth, i, color).Draw();
            }
        }
        static Dictionary SnakeControl(Dictionary con)
        {
            if (!Console.KeyAvailable) return con;
            ConsoleKey key = Console.ReadKey(true).Key;
            con = key switch
            {
                ConsoleKey.D when con != Dictionary.Left => Dictionary.Right,
                ConsoleKey.A when con != Dictionary.Right => Dictionary.Left,
                ConsoleKey.W when con != Dictionary.Down => Dictionary.Up,
                ConsoleKey.S when con != Dictionary.Up => Dictionary.Down,
                _ => con
            };
            return con;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public struct Pixel
    {
        public int X, Y;
        ConsoleColor color { get; set; }

        char simbol;
        public Pixel(int x, int y, ConsoleColor color, char simbol = '*') { X = x; Y = y; this.color = color;this.simbol = simbol;  }
        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(X, Y);
            Console.Write(simbol);
        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}

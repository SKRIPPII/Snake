using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    struct Eat
    {
        const char sim = '+';
        const ConsoleColor color = ConsoleColor.Red;
        public Pixel eaten;
        public Eat(int X,int Y) { eaten = new Pixel(X,Y,color,sim); }
    }
}

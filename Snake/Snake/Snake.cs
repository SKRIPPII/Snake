using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        Random rand = new Random();
        Eat eat;
      public  static int SnakeLength = 3;
        char simbol = 'o';
        public Queue<Pixel> body= new();
        public List<Pixel> copy;
        public Pixel Head;
        ConsoleColor ColorHead;
        ConsoleColor ColorBody;
        public Snake(int X,int Y,ConsoleColor colorhead,ConsoleColor colorbody) 
        { 
            ColorHead = colorhead;
            ColorBody = colorbody;
            Head = new Pixel(X,Y,ColorHead,simbol);
            for (int i = SnakeLength; i >0; i--)
            {
                body.Enqueue(new Pixel(X-i,Y,colorbody,simbol));
            }
            copy = new(body);
            eat = new Eat(rand.Next(10,59),rand.Next(1,19));
            eat.eaten.Draw();
            Draw();
        }
        public void Draw()
        {
            Head.Draw();
                foreach(Pixel p in body)
                {
                     p.Draw();
                }
        }
        public void Clear()
        {
            Head.Clear();
            foreach(Pixel p in body)
            {
                p.Clear();
            }
        }
        public void Move(Dictionary dict)
        {
            Eaten();
            Clear();
            body.Enqueue(new Pixel(Head.X, Head.Y, ColorBody, simbol));
            body.Dequeue();
            copy = new(body);
            Head = dict switch
            {
                Dictionary.Right => new Pixel(Head.X + 1, Head.Y, ColorHead, simbol),
                Dictionary.Up => new Pixel(Head.X, Head.Y - 1, ColorHead, simbol),
                Dictionary.Down => new Pixel(Head.X, Head.Y + 1, ColorHead, simbol),
                Dictionary.Left => new Pixel(Head.X - 1, Head.Y, ColorHead, simbol),
                _=>Head
            };
            Draw();
        }
        public bool Any()
        {
            for (int i = 0; i < copy.Count; i++)
            {
                if (copy[i].X == Head.X && copy[i].Y == Head.Y) return true;
            }
            return false;
        }
        public void Eaten()
        {
            if (eat.eaten.X == Head.X && eat.eaten.Y == Head.Y)
            {
                SnakeLength++;
                body.Enqueue(new Pixel());
                eat = new Eat(rand.Next(3, 57), rand.Next(2, 17));
                eat.eaten.Draw();
            }
        }
    }
}

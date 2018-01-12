using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLogicUtilits.Bombuzle
{
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Size { get; }

        public Square(int size, int r = 0, int c = 0)
        {
            this.Size = size;

            this.X = c;
            this.Y = r;
        }

        public bool IsPointInside(int r, int c)
        {
            return c >= this.X && c < this.X + this.Size &&
                r >= this.Y && r < this.Y + this.Size;
        }
    }
}

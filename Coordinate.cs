using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    class Coordinate
    {
        public char Character { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(char Character, int X, int Y)
        {
            this.Character = Character;
            this.X = X;
            this.Y = Y;
        }
    }

}

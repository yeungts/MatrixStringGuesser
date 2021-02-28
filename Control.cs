using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    abstract class Control : IControls
    {
        public int GetNextX(int direction, int X)
        {
            /* directions:
             * 0 = left
             * 1 = top left
             * 2 = top
             * 3 = top right
             * 4 = right
             * 5 = bottom right
             * 6 = bottom
             * 7 = bottom left
             */
            if (direction == 0 || direction == 1 || direction == 7)
            { return X - 1; }
            else if (direction >= 3 && direction <= 5)
            { return X + 1; }
            return X;
        }
        public int GetNextY(int direction, int Y)
        {
            /* directions:
             * 0 = left
             * 1 = top left
             * 2 = top
             * 3 = top right
             * 4 = right
             * 5 = bottom right
             * 6 = bottom
             * 7 = bottom left
             */
            if (direction >= 1 && direction <= 3)
            { return Y - 1; }
            else if (direction >= 5 && direction <= 7)
            { return Y + 1; }
            return Y;
        }

        public abstract String IsStringExist(String inputString, Coordinate[,] coordinates);
    }
}

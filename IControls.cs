using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixStringGuesser
{
    interface IControls
    {
        String IsStringExist(String inputString, Coordinate[,] coordinates);
    }
}

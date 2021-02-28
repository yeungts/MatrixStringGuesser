using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MatrixStringGuesser
{
    class Matrix
    {
        public Coordinate[,] Coordinates { get; }
        public int Width { get; }
        public int Height { get; }

        public Matrix() { }

        public Matrix(int width)
        {
            this.Width = width;
            this.Coordinates = new Coordinate[width, width];
        }

        public Matrix(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Coordinates = new Coordinate[width, height];
        }

        public string GetMatrixDisplay(Random r)
        {
            String output = "";
            for (int y = 0; y < this.Coordinates.GetLength(1); y++)
            {
                for (int x = 0; x < this.Coordinates.GetLength(0); x++)
                {
                    this.Coordinates[x, y] = new Coordinate(Convert.ToChar(r.Next(97, 123)), x, y);

                    if (x == (Coordinates.GetLength(0) - 1))
                    { output += String.Format("{0}\n", Coordinates[x, y].Character); }
                    else
                    { output += String.Format("{0} ", Coordinates[x, y].Character); }
                }
            }
            return output;
        }

    }
}

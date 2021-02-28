using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixStringGuesser
{
    class Actions : Control
    {
        public override String IsStringExist(String inputString, Coordinate[,] coordinates)
        {
            int stringIndex = 0;
            char[] inputStringArray = inputString.ToCharArray();
            String charPositions = "";

            for (int x = 0; x < coordinates.GetLength(0) && stringIndex != (inputStringArray.Length - 1); x++)
            {
                for (int y = 0; y < coordinates.GetLength(1) && stringIndex != (inputStringArray.Length - 1); y++)
                {
                    if (inputStringArray[stringIndex] == coordinates[x, y].Character)
                    {
                        for (int direction = 0; direction < 8 && stringIndex != (inputStringArray.Length - 1); direction++)
                        {
                            charPositions = "";
                            stringIndex = 0;
                            int newX = base.GetNextX(direction, x);
                            int newY = base.GetNextY(direction, y);
                            // This string will tell user where are the characters, and store the position 
                            // of the first matching character
                            charPositions += String.Format("{0}: (x: {1}, y: {2}); ", coordinates[x, y].Character, x, y);

                            do
                            {
                                // check if the character in the next coordinate matches the next character in string
                                if (newX >= 0 && newX <= (coordinates.GetLength(0) - 1)
                                    && newY >= 0 && newY <= (coordinates.GetLength(1) - 1)
                                    && coordinates[newX, newY].Character == inputStringArray[stringIndex + 1]
                                    && stringIndex != (inputStringArray.Length - 1))
                                {
                                    // if the character in the next coordinate matches the next character in string, 
                                    // get the next coordinate with the same direction and loop through
                                    stringIndex++;
                                    charPositions += String.Format("{0}: (x: {1}, y: {2}); ", 
                                        coordinates[newX, newY].Character, newX, newY);
                                    // only perfrom the following if statement when the cursor isn't 
                                    // at the end of the user input
                                    if (stringIndex != (inputStringArray.Length - 1))
                                    {
                                        newX = base.GetNextX(direction, newX);
                                        if (newX < 0 || newX >= coordinates.GetLength(0)) { break; }
                                        else
                                        { newY = base.GetNextY(direction, newY); }
                                    }
                                }
                                else
                                { break; }
                            } while (stringIndex != (inputStringArray.Length - 1));
                        }
                    }
                }
            }

            if (stringIndex != (inputStringArray.Length - 1))
            { return "\"" + inputString + "\" is not found"; }
            else
            { return "\"" + inputString + "\" is found at:\n" + charPositions; }
        }
    }
}

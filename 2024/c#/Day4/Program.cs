using System.Text.RegularExpressions;

var input = File.ReadAllLines("Day4.txt");
var matrixishInput = input.Select(l => l.ToCharArray()).ToList();

var horizontalCount = input.Sum(l => Regex.Matches(l, "XMAS").Count + Regex.Matches(l, "SAMX").Count);
var verticalCount = 0;
var diagonalCount = 0;
// for each row
for (var r = 0; r < input.Length; r++)
{
    // for each character in the row
    for (var c = 0; c < input[0].Length; c++)
    {
        // if it matches the starting character, we want to search for possible full matches vertically and diagonally
        if (matrixishInput[r][c] == 'X')
        {
            if (r < input.Length - 3)
            {
                // check down
                if (matrixishInput[r + 1][c] == 'M'
                    && matrixishInput[r + 2][c] == 'A'
                    && matrixishInput[r + 3][c] == 'S')
                {
                    verticalCount++;
                }

                // and then check the down diagonals
                if (c < input[0].Length - 3)
                {
                    if (matrixishInput[r + 1][c + 1] == 'M'
                        && matrixishInput[r + 2][c + 2] == 'A'
                        && matrixishInput[r + 3][c + 3] == 'S')
                    {
                        diagonalCount++;
                    }
                }

                if (c >= 3)
                {
                    if (matrixishInput[r + 1][c - 1] == 'M'
                        && matrixishInput[r + 2][c - 2] == 'A'
                        && matrixishInput[r + 3][c - 3] == 'S')
                    {
                        diagonalCount++;
                    }
                }
            }
            if (r >= 3)
            {
                // check up
                if (matrixishInput[r - 1][c] == 'M'
                    && matrixishInput[r - 2][c] == 'A'
                    && matrixishInput[r - 3][c] == 'S')
                {
                    verticalCount++;
                }
                // and then check the up diagonals
                if (c < input[0].Length - 3)
                {
                    if (matrixishInput[r - 1][c + 1] == 'M'
                        && matrixishInput[r - 2][c + 2] == 'A'
                        && matrixishInput[r - 3][c + 3] == 'S')
                    {
                        diagonalCount++;
                    }
                }

                if (c >= 3)
                {
                    if (matrixishInput[r - 1][c - 1] == 'M'
                        && matrixishInput[r - 2][c - 2] == 'A'
                        && matrixishInput[r - 3][c - 3] == 'S')
                    {
                        diagonalCount++;
                    }
                }
            }
            
        }
    }
}

Console.WriteLine($"Part 1: {horizontalCount + verticalCount + diagonalCount}");

var xmas = 0;
for (var r = 1; r < input.Length - 1; r++)
{
    for (var c = 1; c < input[0].Length - 1; c++)
    {
        if (matrixishInput[r][c] == 'A')
        {
            if (matrixishInput[r - 1][c - 1] == 'M' && matrixishInput[r + 1][c + 1] == 'S'
                                                    && matrixishInput[r - 1][c + 1] == 'M' 
                                                    && matrixishInput[r + 1][c - 1] == 'S')
            {
                xmas++;
            }
            if (matrixishInput[r - 1][c - 1] == 'S' && matrixishInput[r + 1][c + 1] == 'M'
                                                    && matrixishInput[r - 1][c + 1] == 'S' 
                                                    && matrixishInput[r + 1][c - 1] == 'M')
            {
                xmas++;
            }
            if (matrixishInput[r - 1][c - 1] == 'M' && matrixishInput[r + 1][c + 1] == 'S'
                                                    && matrixishInput[r - 1][c + 1] == 'S' 
                                                    && matrixishInput[r + 1][c - 1] == 'M')
            {
                xmas++;
            }if (matrixishInput[r - 1][c - 1] == 'S' && matrixishInput[r + 1][c + 1] == 'M'
                                                     && matrixishInput[r - 1][c + 1] == 'M' 
                                                     && matrixishInput[r + 1][c - 1] == 'S')
            {
                xmas++;
            }
        }
    }
}

Console.WriteLine($"Part 2: {xmas}");
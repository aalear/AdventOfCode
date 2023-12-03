using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

var adjacencyMatrix = new bool[input.Length + 1, input[0].Length + 1];
var numberMatrix = new int[input.Length + 1, input[0].Length + 1];

for(var i = 0; i < input.Length; i++)
{
    for(var j = 0; j < input[0].Length; j++)
    {
        var c = input[i][j];

        if (char.IsDigit(c) || char.IsLetter(c) || c == '.')
            continue;

        adjacencyMatrix[i - 1, j - 1] = true;
        adjacencyMatrix[i - 1, j ] = true;
        adjacencyMatrix[i - 1, j + 1] = true;
        adjacencyMatrix[i, j - 1] = true;
        adjacencyMatrix[i, j + 1] = true;
        adjacencyMatrix[i + 1, j - 1] = true;
        adjacencyMatrix[i + 1, j] = true;
        adjacencyMatrix[i + 1, j + 1] = true;
    }
}

var sum1 = 0;
for (var lineIdx = 0; lineIdx < input.Length; lineIdx++)
{
    var line = input[lineIdx];
    
    // Part 1
    var numbers = Regex.Matches(line, @"\d+");
    foreach (Match n in numbers)
    {
        for(var i = n.Index; i < n.Index + n.Length; i++)
        {
            if (adjacencyMatrix[lineIdx, i])
            {
                var number = int.Parse(n.Value);
                sum1 += number;

                // Prep for part 2 here
                for (var j = n.Index; j < n.Index + n.Length; j++)
                {
                    numberMatrix[lineIdx, j] = number;
                }

                break;
            } 
        }
    }
}

// Part 2
var sum2 = 0;
for (var lineIdx = 0; lineIdx < input.Length; lineIdx++)
{
    var line = input[lineIdx];
    
    if(!line.Contains('*'))
        continue;

    var stars = Regex.Matches(line, @"\*");
    foreach (Match s in stars)
    {
        var adjacentNumbers = new List<int>
        {
            numberMatrix[lineIdx - 1, s.Index - 1],
            numberMatrix[lineIdx - 1, s.Index],
            numberMatrix[lineIdx - 1, s.Index + 1],
            numberMatrix[lineIdx, s.Index - 1],
            numberMatrix[lineIdx, s.Index + 1],
            numberMatrix[lineIdx + 1, s.Index - 1],
            numberMatrix[lineIdx + 1, s.Index],
            numberMatrix[lineIdx + 1, s.Index + 1]
        };

        var distinctNumbers = adjacentNumbers.Where(n => n != 0).Distinct();
        if (distinctNumbers.Count() == 2)
        {
            sum2 += distinctNumbers.Aggregate((acc, n) => acc * n);
        }
    }
}

Console.WriteLine($"Part 1: {sum1}");
Console.WriteLine($"Part 2: {sum2}");
using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

int sum1 = 0, sum2 = 0;
foreach (var line in input)
{
    int minRequiredRed = 0, minRequiredGreen = 0, minRequiredBlue = 0;
    
    foreach (Match redCubes in Regex.Matches(line, @"(\d+) red"))
    {
        var red = int.Parse(redCubes.Groups[1].Value);
        if (red > minRequiredRed)
        {
            minRequiredRed = red;
        }
    }
    foreach(Match greenCubes in Regex.Matches(line, @"(\d+) green"))
    {
        var green = int.Parse(greenCubes.Groups[1].Value);
        if (green > minRequiredGreen)
        {
            minRequiredGreen = green;
        }
    }
    foreach(Match blueCubes in Regex.Matches(line, @"(\d+) blue"))
    {
        var blue = int.Parse(blueCubes.Groups[1].Value);
        if (blue > minRequiredBlue)
        {
            minRequiredBlue = blue;
        }
    }

    if (minRequiredRed <= 12 && minRequiredGreen <= 13 && minRequiredBlue <=14) 
    {
        sum1 += int.Parse(line[..line.IndexOf(':')].Replace("Game ", ""));
    }
    
    sum2 += minRequiredRed * minRequiredGreen * minRequiredBlue;
}

Console.WriteLine($"Part 1: {sum1}");
Console.WriteLine($"Part 2: {sum2}");
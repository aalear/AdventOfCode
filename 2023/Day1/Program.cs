using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

// Part 1
Console.WriteLine($"Part 1: {input.Sum(line => int.Parse($"{line.First(char.IsDigit)}{line.Last(char.IsDigit)}"))}");

// Part 2
var sum = 0;
foreach (var line in input)
{
    var matches = Regex.Matches(line, "(?=(one|two|three|four|five|six|seven|eight|nine|[1-9]))");
    sum += int.Parse($"{ToDigit(matches.First().Groups[1].Value)}{ToDigit(matches.Last().Groups[1].Value)}");
}
Console.WriteLine($"Part 2: {sum}");

int ToDigit(string value)
{
    if (value.All(char.IsDigit))
        return int.Parse(value);

    return value switch
    {
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        _ => throw new ArgumentException("Invalid digit", nameof(value))
    };
}
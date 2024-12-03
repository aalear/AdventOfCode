using System.Text.RegularExpressions;

var input = string.Join("", File.ReadAllLines("Day3.txt"));
var mulRegex = new Regex(@"mul\((?<first>\d{1,3}),(?<second>\d{1,3})\)");

var part1 = mulRegex.Matches(input).Sum(MulValue);

var onlyEnabled = Regex.Replace(input, @"(don't\(\)).*?(do\(\)|$)", string.Empty);
var part2 = mulRegex.Matches(onlyEnabled).Sum(MulValue);

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");
return;

int MulValue(Match match) => int.Parse(match.Groups["first"].Value) * int.Parse(match.Groups["second"].Value);
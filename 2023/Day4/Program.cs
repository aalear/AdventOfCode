using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt").ToList();

// Part 1
Console.WriteLine($"Part 1: {input.Sum(i => (int)Math.Pow(2, GetOverlapCount(i) - 1))}");

// Part 2: it's quite slow, but we got there
for (var i = 0; i < input.Count; i++)
{
    var line = input[i];
    var overlapCount = GetOverlapCount(line);
    if (overlapCount > 0)
    {
        var gameId = int.Parse(Regex.Match(line, @"Card\s+(\d+):").Groups[1].Value);
        input.AddRange(input.Skip(gameId).Take(overlapCount));
    }
}
Console.WriteLine($"Part 2: {input.Count}");

// Shared
int GetOverlapCount(string ticket)
{
    var data = ticket[(ticket.IndexOf(':') + 1)..].Split('|');
    var winningNumbers = data[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
    var ticketNumbers = data[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
    return winningNumbers.Intersect(ticketNumbers).Count();
}
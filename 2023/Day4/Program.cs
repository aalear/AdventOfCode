using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt").ToList();

// Part 1
Console.WriteLine($"Part 1: {input.Sum(i => (int)Math.Pow(2, GetOverlapCount(i) - 1))}");

// Part 2
Console.WriteLine($"Part 2: {input.Sum(ProcessTicket)}");

int ProcessTicket(string ticket) => input.Skip(GetCardId(ticket))
                                         .Take(GetOverlapCount(ticket))
                                         .Sum(ProcessTicket) + 1;

int GetCardId(string ticket) => int.Parse(Regex.Match(ticket, @"Card\s+(\d+):").Groups[1].Value);

// Shared
int GetOverlapCount(string ticket)
{
    var data = ticket[(ticket.IndexOf(':') + 1)..].Split('|');
    var winningNumbers = data[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
    var ticketNumbers = data[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
    return winningNumbers.Intersect(ticketNumbers).Count();
}
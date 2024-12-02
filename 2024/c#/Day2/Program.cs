var reports = File.ReadAllLines("../../inputs/day2.txt")
    .Select(line => line.Split(' ').Select(int.Parse).ToArray())
    .ToList();

var safePart1 = 0;
var safePart2 = reports.Count(r =>
{
    var diffs = Enumerable.Range(1, r.Length - 1).Select(i => r[i] - r[i - 1]).ToList();
    if (IsSafe(diffs))
    {
        safePart1++;
        return true;
    }

    for (var skipLevel = 0; skipLevel < r.Length; skipLevel++)
    {
        diffs = Enumerable.Range(1, r.Length - (skipLevel == r.Length - 1 ? 2 : 1))
            .Where(i => i - 1 != skipLevel)
            .Select(i => i == skipLevel ? r[i + 1] - r[i - 1] : r[i] - r[i - 1])
            .ToList();

        if (IsSafe(diffs))
        {
            return true;
        }
    }

    return false;
});

Console.WriteLine($"Part 1: {safePart1}");
Console.WriteLine($"Part 2: {safePart2}");
return;

bool IsSafe(List<int> vals) => vals.All(n => n is >= -3 and <= -1) || vals.All(n => n is >= 1 and <= 3);
var lists = File.ReadAllLines("../../inputs/Day1.txt")
    .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
    .Aggregate((Left: new List<int>(), Right: new List<int>()), (acc, vals) =>
    {
        acc.Left.Add(vals[0]);
        acc.Right.Add(vals[1]);
        return acc;
    });

Console.WriteLine($@"Part 1: {lists.Left.OrderBy(i => i)
                                        .Zip(lists.Right.OrderBy(i => i), (l, r) => Math.Abs(r - l))
                                        .Sum()}");
Console.WriteLine($"Part 2: {lists.Left.Sum(num => num * lists.Right.Count(n => n == num))}");
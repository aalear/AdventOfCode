var input = File.ReadAllLines("input.txt");

var left = new List<int>();
var right = new List<int>();

foreach (var line in input)
{
    var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    left.Add(numbers[0]);
    right.Add(numbers[1]);
}

left.Sort();
right.Sort();

Console.WriteLine($"Part 1: {left.Zip(right, (l, r) => Math.Abs(r - l)).Sum()}");
Console.WriteLine($"Part 2: {left.Sum(num => num * right.Count(n => n == num))}");
var input = File.ReadAllText("input.txt");

Console.WriteLine($"Part 1: {input.Count(c => c == '(') - input.Count(c => c == ')')}");

var floor = 0;
for (var i = 0; i < input.Length; i++)
{
    floor = input[i] == '(' ? floor + 1 : floor - 1;

    if (floor == -1)
    {
        Console.WriteLine($"Part 2: {i + 1}");
        break;
    }
}
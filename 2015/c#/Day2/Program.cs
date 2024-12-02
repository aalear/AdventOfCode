var input = File.ReadAllLines("input.txt");

var paperSqFt = 0;
var ribbonLength = 0;

foreach (var box in input)
{
    var (lwArea, whArea, hlArea, lwPerim, whPerim, hlPerim, vol) = box.Split('x').Select(int.Parse).ToArray() switch
    {
        [var l, var w, var h] => (l * w, w * h, h * l, 2 * (l + w), 2 * (w + h), 2 * (h + l), l * w * h),
        _ => (0, 0, 0, 0, 0, 0, 0)
    };

    paperSqFt += 2 * lwArea + 2 * whArea + 2 * hlArea + new [] { lwArea, whArea, hlArea }.Min();
    ribbonLength += new[] { lwPerim, whPerim, hlPerim }.Min() + vol;
}

Console.WriteLine($"Part 1: {paperSqFt}");
Console.WriteLine($"Part 2: {ribbonLength}");
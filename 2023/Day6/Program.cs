var input = File.ReadAllLines("input.txt");

// Part 1
var raceTimes = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..].Select(int.Parse);
var raceDistances = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..].Select(int.Parse);
var errorMargin = raceTimes.Zip(raceDistances)
                              .Aggregate(1, (acc, x)
                                            => acc * Enumerable.Range(1, x.First).Count(i => i * (x.First - i) > x.Second));
Console.WriteLine($"Part 1: {errorMargin}");

// Part 2
var raceTime = int.Parse(input[0].Replace(" ", "").Split(':')[1]);
var targetDistance = long.Parse(input[1].Replace(" ", "").Split(':')[1]);
var numWaysToWin = Enumerable.Range(1, raceTime).Count(i => (long)i * (raceTime - i) > targetDistance);
Console.WriteLine($"Part 2: {numWaysToWin}");
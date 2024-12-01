var input = File.ReadAllLines("input.txt");

var seeds = input[0].Split(' ')[1..].Select(long.Parse).ToList();

var seedToSoil = new List<Mapping>();
var soilToFertilizer = new List<Mapping>();
var fertilizerToWater = new List<Mapping>();
var waterToLight = new List<Mapping>();
var lightToTemperature = new List<Mapping>();
var temperatureToHumidity = new List<Mapping>();
var humidityToLocation = new List<Mapping>();

for(var i = 2; i < input.Length; i++)
{
    var line = input[i];
    if (string.IsNullOrEmpty(line)) continue;

    i = line switch
    {
        "seed-to-soil map:" => Map(seedToSoil, i),
        "soil-to-fertilizer map:" => Map(soilToFertilizer, i),
        "fertilizer-to-water map:" => Map(fertilizerToWater, i),
        "water-to-light map:" => Map(waterToLight, i),
        "light-to-temperature map:" => Map(lightToTemperature, i),
        "temperature-to-humidity map:" => Map(temperatureToHumidity, i),
        "humidity-to-location map:" => Map(humidityToLocation, i),
        _ => throw new InvalidOperationException()
    };
}

// Part 1
Console.WriteLine($"Part 1: {seeds.Min(GetLocation)}");

// Part 2
// Something... about range overlaps here. We don't need to process the whole seed range, for example, if we know
// it fits entirely into one mapping range.
// Ranges in the input can't overlap. We also know that if a range doesn't fit into another range, the numbers outside
// will simply be the same as they are in the input.
// 
// If a range of seeds is contained exactly in a mapping range, we don't need to check every seed in that range.

// Shared
int Map(ICollection<Mapping> map, int startIndex)
{
    for(var i = startIndex + 1; i < input.Length; i++)
    {
        var line = input[i];
        if (string.IsNullOrEmpty(line)) return i;

        var values = line.Split(' ').Select(long.Parse).ToList();
        map.Add(new Mapping(values[1], values[0], values[2]));
    }

    // If we're here, we hit the last line.
    return input.Length - 1;
}

long GetLocation(long seed)
{
    var soil = GetMappedValue(seedToSoil, seed);
    var fertilizer = GetMappedValue(soilToFertilizer, soil);
    var water = GetMappedValue(fertilizerToWater, fertilizer);
    var light = GetMappedValue(waterToLight, water);
    var temperature = GetMappedValue(lightToTemperature, light);
    var humidity = GetMappedValue(temperatureToHumidity, temperature);
    return GetMappedValue(humidityToLocation, humidity);
}

long GetMappedValue(IEnumerable<Mapping> map, long key)
{
    var mappedVal = map.Select(m => m.GetDestinationValue(key)).SingleOrDefault(m => m.HasValue);
    return mappedVal ?? key;
}

internal record Mapping(long Source, long Destination, long Range)
{
    public long? GetDestinationValue(long key) => key >= Source && key < Source + Range ? Destination + (key - Source) : null;
}
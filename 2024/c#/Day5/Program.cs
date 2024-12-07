var input = File.ReadAllLines("Day5.txt");

var earlierToLater = new Dictionary<int, List<int>>();
var laterToEarlier = new Dictionary<int, List<int>>();
foreach(var line in input.Where(l => l.Contains('|')))
{
    var pages = line.Split('|').Select(int.Parse).ToList();
    AddOrCreate(earlierToLater, pages[0], pages[1]);
    AddOrCreate(laterToEarlier, pages[1], pages[0]);
}

var incorrectlyOrderedUpdates = new List<List<int>>();
var sum = input.Where(l => l.Contains(',')).Sum(l =>
{
    var update = l.Split(',').Select(int.Parse).ToList();

    if (IsValid(update))
    {
        return update[update.Count / 2];
    }
    
    incorrectlyOrderedUpdates.Add(update);
    return 0;
});

Console.WriteLine($"Part 1: {sum}");

var sum2 = incorrectlyOrderedUpdates.Sum(u =>
{
    var correctedUpdate = u;
    while (!IsValid(correctedUpdate))
    {
        correctedUpdate = correctedUpdate.OrderBy(p => p, new PageComparer(earlierToLater, laterToEarlier)).ToList();
    }

    return correctedUpdate[u.Count / 2];
});

Console.WriteLine($"Part 2: {sum2}");
return;

bool IsValid(List<int> update)
{
    for (var i = 0; i < update.Count; i++)
    {
        var page = update[i];
        if (!earlierToLater.TryGetValue(page, out var laterPages)
            || (update.Skip(i + 1).All(p => laterPages.Contains(p))
                && update[..i].All(p => laterToEarlier[page].Contains(p))))
        {
            continue;
        }

        return false;
    }

    return true;
}

void AddOrCreate(Dictionary<int, List<int>> dict, int key, int value)
{
    if (dict.TryGetValue(key, out var values))
    {
        values.Add(value);
    }
    else
    {
        dict[key] = new List<int> { value };
    }
}

internal class PageComparer : IComparer<int>
{
    private readonly Dictionary<int, List<int>> _earlierToLater;
    private readonly Dictionary<int, List<int>> _laterToEarlier;
    public PageComparer(Dictionary<int, List<int>> earlierToLater, Dictionary<int, List<int>> laterToEarlier)
    {
        _earlierToLater = earlierToLater;
        _laterToEarlier = laterToEarlier;
    }
    
    public int Compare(int x, int y)
    {
        if (_earlierToLater.TryGetValue(x, out var earlierList))
        {
            return earlierList.Contains(y) ? -1 : 1;
        }

        if (_laterToEarlier.TryGetValue(x, out var laterList))
        {
            return laterList.Contains(y) ? 1 : -1;
        }

        return 0;
    }
}
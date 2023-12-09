var input = File.ReadAllLines("input.txt");

List<(string Cards, int Bid)> hands = input.Select(line =>
{
    var parts = line.Split(' ');
    return (parts[0], int.Parse(parts[1]));
}).ToList();

// Part 1
var sortedHands = hands.OrderBy(h => h.Cards, new HandComparer()).ToList();
var winnings = sortedHands.Select((hand, index) => hand.Bid * (index + 1)).Sum();
Console.WriteLine($"Part 1: {winnings}");
 
internal class HandComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        var xType = GetType(x);
        var yType = GetType(y);
        
        if(xType > yType)
            return 1;
        if(xType < yType)
            return -1;

        return new CardComparer().Compare(x, y);
    }

    private static HandType GetType(string hand)
    {
        var distinctCardCounts = hand.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
        return distinctCardCounts.Keys.Count switch
        {
            1 => HandType.FiveOfAKind,
            2 => distinctCardCounts.First().Value is 1 or 4 ? HandType.FourOfAKind : HandType.FullHouse,
            3 => distinctCardCounts.Values.Any(v => v == 3) ? HandType.ThreeOfAKind : HandType.TwoPair,
            4 => HandType.OnePair,
            5 => HandType.HighCard,
            _ => throw new InvalidOperationException($"Unexpected hand: {hand}")
        };
    }

    private enum HandType
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }
}

internal class CardComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        foreach (var (i, j) in x.Zip(y))
        {
            var comparison = GetValue(i).CompareTo(GetValue(j));
            if (comparison != 0)
                return comparison;
        }

        return 0;
    } 

    private static int GetValue(char card) => card switch
    {
        'A' => 14,
        'K' => 13,
        'Q' => 12,
        'J' => 11,
        'T' => 10,
        _ => int.Parse(card.ToString())
    };
}
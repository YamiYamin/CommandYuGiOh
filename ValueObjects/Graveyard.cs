using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Graveyard
{
    private readonly List<Card> _cards = [];

    public bool IsEmpty()
    {
        return _cards.Count == 0;
    }

    public void Place(Card card)
    {
        _cards.Add(card);
    }

    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine(" □:0");
            return;
        }

        Console.WriteLine($" □:{_cards.Count}");
    }

    public void PrintGraveyardList()
    {
        if (IsEmpty())
        {
            return;
        }

        Console.Write($"1. {_cards.First()}");
        for (int i = 1; i < _cards.Count; i++)
        {
            Console.Write($", {i + 1}. {_cards[i]}");
        }
        Console.WriteLine();
    }
}

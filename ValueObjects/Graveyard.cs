using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Graveyard
{
    private readonly List<Card> _cards = [];

    public bool IsEmpty()
    {
        return _cards.Count == 0;
    }

    public void Put(Card card)
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
}

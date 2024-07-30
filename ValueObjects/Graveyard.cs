using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Graveyard : CardListBase
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
            Console.WriteLine("墓地がありません。");
            return;
        }

        Console.Write("墓地: ");
        PrintCards(_cards, true);
    }
}

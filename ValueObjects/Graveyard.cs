using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Graveyard
{
    private List<Card> cards = [];

    public bool IsEmpty()
    {
        return cards.Count == 0;
    }

    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine(" □:0");
            return;
        }

        Console.WriteLine($" □:{cards.Count}");
    }
}

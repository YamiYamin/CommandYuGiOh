namespace YuGiOh.ValueObjects;

public class Hand
{
    private readonly List<Card> _cards = [];

    public void Add(Card drawCard)
    {
        _cards.Add(drawCard);
    }

    public bool Exists()
    {
        return _cards.Count > 0;
    }

    public Card GetCard(int index)
    {
        if (_cards.Count == 0 || index >= _cards.Count)
        {
            return Card.Empty;
        }

        return _cards[index];
    }

    public void Remove(Card card)
    {
        _cards.Remove(card);
    }

    public void PrintHands(bool showIndex = true)
    {
        if (!Exists())
        {
            return;
        }
        if (showIndex)
        {
            Console.Write($"{0}. {_cards.First().Name}");
            for (int i = 1; i < _cards.Count; i++)
            {
                Console.Write($", {i}. {_cards[i].Name}");
            }
        }
        else
        {
            Console.Write($"{_cards.First().Name}");
            for (int i = 1; i < _cards.Count; i++)
            {
                Console.Write($", {_cards[i].Name}");
            }
        }
        Console.WriteLine();
    }
}

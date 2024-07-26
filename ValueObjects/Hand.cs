using YuGiOh.ValueObjects.Cards;

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
        if (index < 0 || index >= _cards.Count)
        {
            return Card.Empty;
        }

        if (_cards.Count == 0)
        {

            return Card.Empty;
        }

        return _cards[index];
    }

    public void Remove(Card card)
    {
        _cards.Remove(card);
    }

    public void PrintMonsters(bool showIndex = true)
    {
        if (!Exists())
        {
            return;
        }

        var monsters = GetMonsters();
        PrintCards(monsters, showIndex);
    }

    private List<Monster> GetMonsters()
    {
        List<Monster> monsters = [];
        foreach (var card in _cards)
        {
            if (card is Monster monster)
            {
                monsters.Add(monster);
            }
        }
        return monsters;
    }

    public void PrintHands(bool showIndex = true)
    {
        if (!Exists())
        {
            return;
        }

        PrintCards(_cards, showIndex);
    }

    private static void PrintCards<T>(List<T> cards, bool showIndex) where T : Card
    {
        if (showIndex)
        {
            Console.Write($"{1}. {cards.First().Name}");
            for (int i = 2; i < cards.Count + 1; i++)
            {
                Console.Write($", {i}. {cards[i - 1].Name}");
            }
        }
        else
        {
            Console.Write($"{cards.First().Name}");
            for (int i = 1; i < cards.Count; i++)
            {
                Console.Write($", {cards[i].Name}");
            }
        }
        Console.WriteLine();
    }

    public void Print()
    {
        if (!Exists())
        {
            Console.WriteLine(" :0");
            return;
        }
        Console.WriteLine($"¡:{_cards.Count}");
    }
}


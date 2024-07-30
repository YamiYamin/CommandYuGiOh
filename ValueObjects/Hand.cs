using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Hand : CardListBase
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
            throw new ArgumentOutOfRangeException(nameof(index), "�ԍ�������������܂���B");
        }

        if (_cards.Count == 0)
        {
            throw new Exception("�f�b�L�ɃJ�[�h������܂���B");
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
            Console.WriteLine("��D������܂���B");
            return;
        }


        Console.Write("��D: ");
        PrintCards(_cards, showIndex);
    }

    public void Print()
    {
        if (!Exists())
        {
            Console.WriteLine("��:0");
            return;
        }
        Console.WriteLine($"��:{_cards.Count}");
    }
}

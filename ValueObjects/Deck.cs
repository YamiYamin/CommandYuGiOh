using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Deck : CardListBase
{
    // インデックス0がデッキトップ, 後ろがデッキボトム
    private List<Card> cards = [];

    public Deck()
    {
    }

    public Deck(List<Card> cards)
    {
        this.cards.AddRange(cards);
    }

    public Card Pop()
    {
        if (cards.Count == 0)
        {
            throw new IndexOutOfRangeException();
        }

        var card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    public void Add(Card card, bool isTop)
    {
        if (isTop)
        {
            cards.Insert(0, card);
        }
        else
        {
            cards.Add(card);
        }
    }

    public Card Remove(int index)
    {
        if (index < 0 || index >= cards.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "");
        }
        var card = cards[index];
        cards.RemoveAt(index);
        return card;
    }

    public void Shuffle()
    {
        cards = [.. cards.OrderBy(x => Random.Shared.Next())];
    }

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

        Console.WriteLine($" ■:{cards.Count}");
    }

    public void PrintDeckList(bool showIndex = true)
    {
        if (IsEmpty())
        {
            Console.WriteLine("デッキがありません。");
            return;
        }

        Console.Write("デッキ: ");
        PrintCards(cards, showIndex);
    }
}

using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Deck
{
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
    
    public void Shuffle()
    {
        cards = [.. cards.OrderBy(x => Random.Shared.Next())];
    }

    public bool IsEmpty()
    {
        return cards.Count == 0;
    }
}

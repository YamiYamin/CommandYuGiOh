using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Deck
{
    public List<Card> Cards { get; set; } = [];

    public Deck()
    {
    }

    public Deck(List<Card> cards)
    {
        Cards.AddRange(cards);
    }

    public Card Pop()
    {
        if (Cards.Count == 0)
        {
            throw new IndexOutOfRangeException();
        }

        var card = Cards[0];
        Cards.RemoveAt(0);
        return card;
    }
    
    public void Shuffle()
    {
        Cards = [.. Cards.OrderBy(x => Random.Shared.Next())];
    }
}

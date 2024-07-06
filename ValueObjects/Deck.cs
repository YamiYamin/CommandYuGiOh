using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Deck : List<Card>
{
    public Deck()
    {
    }

    public Deck(List<Card> cards)
    {
        AddRange(cards);
    }

    public Card Pop()
    {
        if (!this.Any())
        {
            throw new IndexOutOfRangeException();
        }

        var card = this[0];
        RemoveAt(0);
        return card;
    }
}

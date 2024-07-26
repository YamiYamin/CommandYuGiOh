using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Player(Deck deck, DuelOptions options)
{
    public Deck Deck { get; set; } = deck;
    public Hand Hand { get; set; } = new();
    public Field Field { get; set; } = new();
    public Graveyard Graveyard { get; set; } = new();

    public DuelOptions Options { get; set; } = options;

    public Card Draw()
    {
        if (Deck.IsEmpty())
        {
            return Card.Empty;
        }
        var drawCard = Deck.Pop();
        Hand.Add(drawCard);
        return drawCard;
    }

    public void Place(Card card, Zone zone)
    {
        Hand.Remove(card);

        zone.Insert(card, 0);
    }

    public void PlaceOnGraveyard(Card card)
    {
        Hand.Remove(card);

        Graveyard.Place(card);
    }

    public void PlaceOnDeck(Card card, bool isTop)
    {
        Hand.Remove(card);

        Deck.Add(card, isTop);
    }

    public void PrintField()
    {
        Field.PrintFieldZone();
        Field.PrintMonsterZone();
        Graveyard.Print();
        Field.PrintSpellTrapZone();
        Deck.Print();
        Hand.Print();
    }
}

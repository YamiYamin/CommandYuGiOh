using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Player(Deck deck, DuelOptions options)
{
    public Deck Deck { get; set; } = deck;
    public Hand Hand { get; set; } = new();
    public Field Field { get; set; } = new();

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

    public void Summon(Card card, MonsterZone monsterZone)
    {
        Hand.Remove(card);
        
        monsterZone.Insert(card, 0);
    }
}

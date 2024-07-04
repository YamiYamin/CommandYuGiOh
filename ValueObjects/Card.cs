namespace YuGiOh.ValueObjects;

public class Card
{
    public static Card Empty = new("", "");
    public string Id { get; }
    public string Name { get; }
    public CardType Type { get; }

    public Card(string id, string name, CardType type=CardType.Monster)
    {
        Id = id;
        Name = name;
        Type = type;
    }
}

public enum CardType
{
    Monster,
    Spell,
    Trap,
}

namespace YuGiOh.ValueObjects;

public class Card
{
    public static Card Empty { get; } = new("", "", CardType.Monster);
    public string Id { get; }
    public string Name { get; }
    public CardType Type { get; }

    public Card(string id, string name, CardType type)
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

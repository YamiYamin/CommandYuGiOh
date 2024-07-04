namespace YuGiOh.ValueObjects;

public class Card
{
    public static Card Empty { get; } = new(string.Empty, string.Empty);
    public string Id { get; }
    public string Name { get; }

    public Card(string id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Monster : Card
{
    public Monster(string id, string name)
        : base(id, name)
    {
    }
}

public class Spell : Card
{
    public Spell(string id, string name)
        : base(id, name)
    {
    }
}

public class Trap : Card
{
    public Trap(string id, string name)
        : base(id, name)
    {
    }
}

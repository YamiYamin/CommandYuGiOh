namespace YuGiOh.ValueObjects.Cards;

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

public enum FaceDirection
{
    FaceUp,
    FaceDown,
}

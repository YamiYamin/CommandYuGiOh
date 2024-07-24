namespace YuGiOh.ValueObjects.Cards;

public class Card(string id, string name)
{
    public static Card Empty { get; } = new(string.Empty, string.Empty);
    public string Id { get; } = id;
    public string Name { get; } = name;
}

public enum FaceDirection
{
    FaceUp,
    FaceDown,
}

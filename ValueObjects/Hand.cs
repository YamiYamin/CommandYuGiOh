namespace YuGiOh.ValueObjects;

public class Hand : List<Card>
{
    public Card GetCard(int index)
    {
        if (Count == 0)
        {
            return Card.Empty;
        }

        return this[index];
    }
}

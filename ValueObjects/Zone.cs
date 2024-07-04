namespace YuGiOh.ValueObjects;

public class Zone
{
    public List<Card> Cards { get; set; } = [];

    public void Put(Card card)
    {
        Cards.Add(card);
    }

    public void Push(Card card)
    {
        Cards.Insert(0, card);
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

    public bool CardExists()
    {
        return Cards.Count > 0;
    }
}

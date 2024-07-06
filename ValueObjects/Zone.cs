using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class FieldZone : Zone
{
}

public class MonsterZone : Zone
{
}

public class SpellTrapZone : Zone
{
}

public abstract class Zone
{
    public List<Card> Cards { get; set; } = [];

    public void Insert(Card card, int index)
    {
        Cards.Insert(index, card);
    }

    public Card Take(int index)
    {
        if (Cards.Count <= index)
        {
            throw new IndexOutOfRangeException();
        }

        var card = Cards[index];
        Cards.RemoveAt(index);
        return card;
    }

    public bool CardExists()
    {
        return Cards.Count > 0;
    }
}

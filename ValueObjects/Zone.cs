using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class FieldZone : Zone
{
    public override void Print()
    {
        WriteLine();
    }
}

public class MonsterZoneLeft : MonsterZone
{
    public override void Print() 
    {
        Write();
    }
}

public class MonsterZoneCenter : MonsterZone
{
    public override void Print()
    {
        Write();
    }
}

public class MonsterZoneRight : MonsterZone
{
    public override void Print()
    {
        Write();
    }
}

public class SpellTrapZoneLeft : MonsterZone
{
    public override void Print() 
    {
        Write();
    }
}

public class SpellTrapZoneCenter : MonsterZone
{
    public override void Print()
    {
        Write();
    }
}

public class SpellTrapZoneRight : MonsterZone
{
    public override void Print()
    {
        Write();
    }
}

public abstract class MonsterZone : Zone
{
}

public abstract class SpellTrapZone : Zone
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

    public abstract void Print();

    protected void WriteLine()
    {
        if (CardExists())
        {
            Console.WriteLine("■");
        }
        else
        {
            Console.WriteLine("□");
        }
    }

    protected void Write()
    {
        if (CardExists())
        {
            Console.Write("■");
        }
        else
        {
            Console.Write("□");
        }
    }
}

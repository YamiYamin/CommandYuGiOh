using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public sealed class FieldZone : Zone
{
    public override string Name { get; protected set; } = "フィールドゾーン";

    public override void Print()
    {
        WriteLine();
    }
}

public class MonsterZoneLeft : MonsterZone
{
    public MonsterZoneLeft()
    {
        Name += "左";
    }

    public override void Print()
    {
        Write();
    }
}

public class MonsterZoneCenter : MonsterZone
{
    public MonsterZoneCenter()
    {
        Name += "中央";
    }

    public override void Print()
    {
        Write();
    }
}

public class MonsterZoneRight : MonsterZone
{
    public MonsterZoneRight()
    {
        Name += "右";
    }

    public override void Print()
    {
        Write();
    }
}

public class SpellTrapZoneLeft : SpellTrapZone
{
    public SpellTrapZoneLeft()
    {
        Name += "左";
    }

    public override void Print()
    {
        Write();
    }
}

public class SpellTrapZoneCenter : SpellTrapZone
{
    public SpellTrapZoneCenter()
    {
        Name += "中央";
    }

    public override void Print()
    {
        Write();
    }
}

public class SpellTrapZoneRight : SpellTrapZone
{
    public SpellTrapZoneRight()
    {
        Name += "右";
    }

    public override void Print()
    {
        Write();
    }
}

public abstract class MonsterZone : Zone
{
    public override string Name { get; protected set; } = "モンスターゾーン";
}

public abstract class SpellTrapZone : Zone
{
    public override string Name { get; protected set; } = "魔法＆罠ゾーン";
}

public abstract class Zone
{
    public abstract string Name { get; protected set; }

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

namespace YuGiOh.ValueObjects;

public class Field
{
    public Zone FieldZone { get; set; } = new();
    public Zone MonsterZoneLeft { get; set; } = new();
    public Zone MonsterZoneCenter { get; set; } = new();
    public Zone MonsterZoneRight { get; set; } = new();
    public Zone SpellTrapZoneLeft { get; set; } = new();
    public Zone SpellTrapZoneRight { get; set; } = new();
    public Zone SpellTrapZoneCenter { get; set; } = new();

    private Zone GetZone(ZoneType zoneType)
    {
        return zoneType switch
        {
            ZoneType.FieldZone => FieldZone,
            ZoneType.MonsterZoneLeft => MonsterZoneLeft,
            ZoneType.MonsterZoneCenter => MonsterZoneCenter,
            ZoneType.MonsterZoneRight => MonsterZoneRight,
            ZoneType.SpellTrapZoneLeft => SpellTrapZoneLeft,
            ZoneType.SpellTrapZoneRight => SpellTrapZoneRight,
            ZoneType.SpellTrapZoneCenter => SpellTrapZoneCenter,
            _ => throw new NotImplementedException()
        };
    }

    public void Put(Card card, ZoneType zoneType)
    {
        var zone = GetZone(zoneType);
        if (zone.CardExists())
        {
            zone.Push(card);
        }
        zone.Put(card);
    }
}

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

public enum ZoneType
{
    MonsterZoneLeft,
    MonsterZoneCenter,
    MonsterZoneRight,
    FieldZone,
    SpellTrapZoneLeft,
    SpellTrapZoneRight,
    SpellTrapZoneCenter,
}

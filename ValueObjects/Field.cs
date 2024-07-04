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
        zone.Set(card);
    }

    public bool Exists(ZoneType zoneType)
    {
        var zone = GetZone(zoneType);
        return zone.Exists();
    }
}

public class Zone
{
    public Card Card { get; set; } = Card.Empty;

    public void Set(Card card)
    {
        Card = card;
    }

    public bool Exists()
    {
        return Card != Card.Empty;
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

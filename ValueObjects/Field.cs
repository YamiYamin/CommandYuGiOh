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

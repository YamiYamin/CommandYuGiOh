
namespace YuGiOh.ValueObjects;

public class Field
{
    public FieldZone FieldZone { get; set; } = new();
    public MonsterZone MonsterZoneLeft { get; set; } = new();
    public MonsterZone MonsterZoneCenter { get; set; } = new();
    public MonsterZone MonsterZoneRight { get; set; } = new();
    public SpellTrapZone SpellTrapZoneLeft { get; set; } = new();
    public SpellTrapZone SpellTrapZoneRight { get; set; } = new();
    public SpellTrapZone SpellTrapZoneCenter { get; set; } = new();

    public List<Zone> ZoneList { get; }

    public Field()
    {
        ZoneList = 
        [
            FieldZone,
            MonsterZoneLeft, MonsterZoneCenter, MonsterZoneRight,
            SpellTrapZoneLeft, SpellTrapZoneCenter, SpellTrapZoneRight,
        ];
    }
    public MonsterZone? GetMonsterZone(int zoneNum)
    {
        return (MonsterZoneType)zoneNum switch
        {
            MonsterZoneType.MonsterZoneLeft => MonsterZoneLeft,
            MonsterZoneType.MonsterZoneCenter => MonsterZoneCenter,
            MonsterZoneType.MonsterZoneRight => MonsterZoneRight,
            _ => null,
        };
    }

}

public enum MonsterZoneType
{
    MonsterZoneLeft,
    MonsterZoneCenter,
    MonsterZoneRight,
}

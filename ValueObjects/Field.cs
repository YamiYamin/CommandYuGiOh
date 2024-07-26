
namespace YuGiOh.ValueObjects;

public class Field
{
    public FieldZone FieldZone { get; set; } = new();
    public MonsterZoneLeft MonsterZoneLeft { get; set; } = new();
    public MonsterZoneCenter MonsterZoneCenter { get; set; } = new();
    public MonsterZoneRight MonsterZoneRight { get; set; } = new();
    public SpellTrapZoneLeft SpellTrapZoneLeft { get; set; } = new();
    public SpellTrapZoneCenter SpellTrapZoneCenter { get; set; } = new();
    public SpellTrapZoneRight SpellTrapZoneRight { get; set; } = new();

    public List<Zone> ZoneList { get; }
    public List<Zone> MonsterZoneList { get; }
    public List<Zone> SpellTrapZoneList { get; }

    public Field()
    {
        ZoneList =
            [
                FieldZone,
                MonsterZoneLeft, MonsterZoneCenter, MonsterZoneRight,
                SpellTrapZoneLeft, SpellTrapZoneCenter, SpellTrapZoneRight,
            ];

        MonsterZoneList =
            [
                MonsterZoneLeft, MonsterZoneCenter, MonsterZoneRight,
            ];
        SpellTrapZoneList =
            [
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

    public Zone? GetZone(int zoneNum)
    {
        return (ZoneType)zoneNum switch
        {
            ZoneType.FieldZone => FieldZone,
            ZoneType.MonsterZoneLeft => MonsterZoneLeft,
            ZoneType.MonsterZoneCenter => MonsterZoneCenter,
            ZoneType.MonsterZoneRight => MonsterZoneRight,
            ZoneType.SpellTrapZoneLeft => SpellTrapZoneLeft,
            ZoneType.SpellTrapZoneCenter => SpellTrapZoneCenter,
            ZoneType.SpellTrapZoneRight => SpellTrapZoneRight,
            _ => null,
        };
    }

    public void PrintFieldZone()
    {
        FieldZone.Print();
    }

    public void PrintMonsterZone()
    {
        foreach (var zone in MonsterZoneList)
        {
            zone.Print();
        }
    }

    public void PrintSpellTrapZone()
    {
        foreach (var zone in SpellTrapZoneList)
        {
            zone.Print();
        }
    }
}

public enum MonsterZoneType
{
    MonsterZoneLeft,
    MonsterZoneCenter,
    MonsterZoneRight,
}


public enum ZoneType
{
    FieldZone,
    MonsterZoneLeft,
    MonsterZoneCenter,
    MonsterZoneRight,
    SpellTrapZoneLeft,
    SpellTrapZoneCenter,
    SpellTrapZoneRight,
}

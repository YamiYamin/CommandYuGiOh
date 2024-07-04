using System.Dynamic;

namespace YuGiOh.ValueObjects;

public class Field
{
    public Zone ExtraMonsterZone { get; set; } = new();
    public Zone MonsterZone1 { get; set; } = new();
    public Zone MonsterZone2 { get; set; } = new();
    public Zone MonsterZone3 { get; set; } = new();
    public Zone MonsterZone4 { get; set; } = new();
    public Zone MonsterZone5 { get; set; } = new();
    public Zone FieldZone { get; set; } = new();
    public Zone PendulumZoneLeft { get; set; } = new();
    public Zone PendulumZoneRight { get; set; } = new();
    public Zone SpellTrapZone1 { get; set; } = new();
    public Zone SpellTrapZone2 { get; set; } = new();
    public Zone SpellTrapZone3 { get; set; } = new();

    public void PutMonsterZone1(Card card)
    {
        Put(card, MonsterZone1);
    }

    private static void Put(Card card, in Zone zone)
    {
        zone.Set(card);
    }
}

public class Zone
{
    public Card Card { get; set; } = Card.Empty;

    public void Set(Card card)
    {
        Card = card;
    }
}

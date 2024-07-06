namespace YuGiOh.ValueObjects.Cards;

public class Monster : Card
{
    public BattlePosition battlePosition = BattlePosition.AtackPosition;

    public Monster(string id, string name)
        : base(id, name)
    {
    }
}

public enum BattlePosition
{
    AtackPosition,
    DefensePosition,
}

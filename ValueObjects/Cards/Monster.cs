namespace YuGiOh.ValueObjects.Cards;

public class Monster(string id, string name) : Card(id, name)
{
    public BattlePosition battlePosition = BattlePosition.AtackPosition;
}

public enum BattlePosition
{
    AtackPosition,
    DefensePosition,
}

using System.ComponentModel;

namespace YuGiOh.ValueObjects.Cards;

public class FieldSpell : Spell
{
    public FieldSpell(string id, string name)
        : base(id, name)
    {
    }
}

public class Spell : Card
{
    public Spell(string id, string name)
        : base(id, name)
    {
    }
}
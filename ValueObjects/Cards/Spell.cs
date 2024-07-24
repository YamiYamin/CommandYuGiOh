using System.ComponentModel;

namespace YuGiOh.ValueObjects.Cards;

public class FieldSpell(string id, string name) : Spell(id, name)
{
}

public class Spell(string id, string name) : Card(id, name)
{
}
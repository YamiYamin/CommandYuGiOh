namespace YuGiOh.ValueObjects;

public class Player
{
    public Deck Deck { get; set; }
    public Hand Hand { get; set; }
    public Field Field { get; set; }

    public Player(Deck deck, DuelOptions options)
    {
        Deck = deck;
        Hand = [];
        Field = new();
        for (int i = 0; i < options.NumOfHands; i++)
        {
            Draw();
        }
    }

    public void Draw()
    {
        if (!Deck.Any())
        {
            Console.WriteLine($"デッキがありません。");
            return;
        }
        var drawCard = Deck.Pop();
        Hand.Add(drawCard);
        Console.WriteLine($"{drawCard.Name}をドローしました。");
    }

    public void Summon(Card card)
    {
        Field.Put(card, ZoneType.MonsterZoneLeft);
        Hand.Remove(card);
        Console.WriteLine($"{card.Name}を召喚しました。");
    }

    public void MainLoop()
    {
        while (true)
        {
            Console.WriteLine($@"★ コマンドを選んでください。");
            Console.WriteLine($@"1. ドロー, 2. 召喚");
            Console.Write("> ");
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("不正な入力値です");
                continue;
            }
            switch (num)
            {

                case 1:
                    Draw();
                    break;
                case 2:
                    if (Hand.Count <= 0)
                    {
                        Console.WriteLine("手札がありません。");
                        continue;
                    }
                    Console.WriteLine($@"★ 手札から召喚するモンスターを選んでください。");
                    Console.Write($"{1}. {Hand.First().Name}");
                    for (int i = 1; i < Hand.Count; i++)
                    {
                        Console.Write($", {i + 1}. {Hand[i].Name}");
                    }
                    Console.WriteLine();
                    Console.Write("> ");
                    if (!int.TryParse(Console.ReadLine(), out int index))
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    if (index < 1 || index > Hand.Count)
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    Summon(Hand[index - 1]);
                    break;
                default:
                    Console.WriteLine("不正な入力値です");
                    break;
            }
        }
    }
}

public class DuelOptions
{
    public int NumOfHands { get; set; }
}

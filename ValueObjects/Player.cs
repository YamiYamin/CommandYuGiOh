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
        Field.PutMonsterZone1(card);
        Hand.Remove(card);
        Console.WriteLine($"{card.Name}を召喚しました。");
    }

    public void MainLoop()
    {
        while (true)
        {
            Console.WriteLine($@"★コマンドの番号を入力してください。");
            Console.WriteLine($@"1. ドロー, 2. 召喚");
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
                    Console.WriteLine($@"★召喚するモンスターの番号を入力してください。");
                    for (int i = 0; i < Hand.Count; i ++)
                    {
                        Console.WriteLine($"{i + 1}. {Hand[i].Name}");
                    }
                    if (!int.TryParse(Console.ReadLine(), out num))
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    if (num < 1 || num > Hand.Count)
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    Summon(Hand[num - 1]);
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

using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class Player
{
    public Deck Deck { get; set; }
    public Hand Hand { get; set; }
    public Field Field { get; set; }

    public DuelOptions Options { get; set; }

    public Player(Deck deck, DuelOptions options)
    {
        Deck = deck;
        Hand = new();
        Field = new();
        Options = options;
    }

    public Card Draw()
    {
        if (!Deck.Any())
        {
            return Card.Empty;
        }
        var drawCard = Deck.Pop();
        Hand.Add(drawCard);
        return drawCard;
    }

    public void Summon(Card card, MonsterZone monsterZone)
    {
        Hand.Remove(card);
        
        monsterZone.Insert(card, 0);
    }

    public void MainLoop()
    {
        for (int i = 0; i < Options.NumOfHands; i++)
        {
            var drawCard = Draw();
            if (drawCard == Card.Empty)
            {
                Console.WriteLine($"デッキがありません。");
                break;
            }
            Console.WriteLine($"{drawCard.Name}をドローしました。");
        }

        while (true)
        {
            Console.WriteLine($@"★ コマンドを選んでください。");
            Console.WriteLine($@"0. ドロー, 1. 召喚");
            Console.Write("> ");
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("不正な入力値です");
                continue;
            }
            switch (num)
            {

                case 0:
                    var drawCard = Draw();
                    if (drawCard == Card.Empty)
                    {
                        Console.WriteLine($"デッキがありません。");
                        continue;
                    }
                    Console.WriteLine($"{drawCard.Name}をドローしました。");
                    break;
                case 1:
                    if (!Hand.Exists())
                    {
                        Console.WriteLine("手札がありません。");
                        continue;
                    }
                    Console.WriteLine($@"★ 手札から召喚するモンスターを選んでください。");
                    Hand.PrintHands();
                    Console.Write("> ");
                    if (!int.TryParse(Console.ReadLine(), out int index))
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    var card = Hand.GetCard(index);
                    if (card == Card.Empty)
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    Console.WriteLine("召喚する位置を選んでください。");
                    Console.WriteLine($"0. 左端, 1. 中央, 2. 右端");
                    if (!int.TryParse(Console.ReadLine(), out index))
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    var zone = Field.GetMonsterZone(0);
                    if (zone is null)
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    Console.WriteLine($"{card.Name}を召喚しました。");
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

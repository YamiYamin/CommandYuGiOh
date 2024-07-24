using YuGiOh.ValueObjects;
using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

internal class Game(Deck deck, DuelOptions options)
{
    public Player Player { get; } = new Player(deck, options);

    public void MainLoop()
    {
        if (options.InitShuffle)
        {
            Player.Deck.Shuffle();
        }
        for (int i = 0; i < Player.Options.NumOfHands; i++)
        {
            var drawCard = Player.Draw();
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
                    var drawCard = Player.Draw();
                    if (drawCard == Card.Empty)
                    {
                        Console.WriteLine($"デッキがありません。");
                        continue;
                    }
                    Console.WriteLine($"{drawCard.Name}をドローしました。");
                    break;
                case 1:
                    if (!Player.Hand.Exists())
                    {
                        Console.WriteLine("手札がありません。");
                        continue;
                    }
                    Console.WriteLine($@"★ 手札から召喚するモンスターを選んでください。");
                    Player.Hand.PrintHands();
                    Console.Write("> ");
                    if (!int.TryParse(Console.ReadLine(), out int index))
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    var card = Player.Hand.GetCard(index);
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
                    var zone = Player.Field.GetMonsterZone(0);
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

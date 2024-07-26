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
            Player.PrintField();
            Console.WriteLine($@"★ コマンドを選んでください。");
            Console.WriteLine($@"0. ドロー, 1. 置く");
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
                    Console.WriteLine($@"★ 手札から置くカードを選んでください。");
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
                    Console.WriteLine("置く位置を選んでください。");
                    Console.WriteLine($"1. フィールドゾーン");
                    Console.WriteLine($"2. モンスターゾーン左, 3. モンスターゾーン中央, 4. モンスターゾーン右");
                    Console.WriteLine($"5. 魔法＆罠ゾーン左, 6. 魔法＆罠ゾーン中央, 7. 魔法＆罠ゾーン右");
                    Console.Write("> ");
                    if (!int.TryParse(Console.ReadLine(), out index))
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    var zone = Player.Field.GetZone(index - 1);
                    if (zone is null)
                    {
                        Console.WriteLine("不正な入力値です");
                        continue;
                    }
                    Player.Put(card, zone);
                    Console.WriteLine($"{card.Name}を{zone.Name}に置きました。");
                    break;
                default:
                    Console.WriteLine("不正な入力値です");
                    break;
            }
        }
    }
}

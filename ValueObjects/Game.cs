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
            Console.WriteLine($@"1. ドロー, 2. 置く");
            Console.Write("> ");
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                WriteLineInvalidInput();
                continue;
            }
            switch (num)
            {
                case 1:
                    var drawCard = Player.Draw();
                    if (drawCard == Card.Empty)
                    {
                        WriteLineResult($"デッキがありません。");
                        continue;
                    }
                    WriteLineResult($"{drawCard.Name}をドローしました。");
                    break;
                case 2:
                    if (!Player.Hand.Exists())
                    {
                        WriteLineResult("手札がありません。");
                        continue;
                    }
                    Console.WriteLine($@"★ 手札から置くカードを選んでください。");
                    Player.Hand.PrintHands();
                    Console.Write("> ");
                    if (!int.TryParse(Console.ReadLine(), out int index))
                    {
                        WriteLineInvalidInput();
                        continue;
                    }
                    var card = Player.Hand.GetCard(index - 1);
                    if (card == Card.Empty)
                    {
                        WriteLineInvalidInput();
                        continue;
                    }
                    Console.WriteLine($"{card.Name}を置く位置を選んでください。");
                    Console.WriteLine($"1. フィールドゾーン");
                    Console.WriteLine($"2. モンスターゾーン左, 3. モンスターゾーン中央, 4. モンスターゾーン右");
                    Console.WriteLine($"5. 魔法＆罠ゾーン左, 6. 魔法＆罠ゾーン中央, 7. 魔法＆罠ゾーン右");
                    Console.Write("> ");
                    if (!int.TryParse(Console.ReadLine(), out index))
                    {
                        WriteLineInvalidInput();
                        continue;
                    }
                    var zone = Player.Field.GetZone(index - 1);
                    if (zone is null)
                    {
                        WriteLineInvalidInput();
                        continue;
                    }
                    Player.Place(card, zone);
                    WriteLineResult($"{card.Name}を{zone.Name}に置きました。");
                    break;
                default:
                    WriteLineInvalidInput();
                    break;
            }
        }
    }

    private static void WriteLineResult(string value)
    {
        Console.Clear();
        Console.WriteLine(value);
    }

    private static void WriteLineInvalidInput()
    {
        Console.Clear();
        Console.WriteLine("不正な入力値です");
    }
}

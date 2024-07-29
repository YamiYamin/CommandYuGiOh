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
            Console.WriteLine($"{drawCard.Name}をドローしました。");
        }

        while (true)
        {
            try
            {
                Player.PrintField();
                Console.WriteLine($@"★ コマンドを選んでください。");
                Console.WriteLine($@"1. ドロー, 2. 置く, 3. 確認");
                int num = ReadLineNum();
                switch (num)
                {
                    case 1:
                        var drawCard = Player.Draw();
                        WriteLineResult($"{drawCard.Name}をドローしました。");
                        break;
                    case 2:
                        if (!Player.Hand.Exists())
                        {
                            WriteLineResult("手札がありません。");
                        }
                        Console.WriteLine($@"★ 手札から置くカードを選んでください。");
                        Player.Hand.PrintHands();
                        int cardIndex = ReadLineNum() - 1;
                        var card = Player.Hand.GetCard(cardIndex);
                        
                        Console.WriteLine($"{card.Name}を置く位置を選んでください。");
                        Console.WriteLine($"1. フィールドゾーン");
                        Console.WriteLine($"2. モンスターゾーン左, 3. モンスターゾーン中央, 4. モンスターゾーン右");
                        Console.WriteLine($"5. 魔法＆罠ゾーン左, 6. 魔法＆罠ゾーン中央, 7. 魔法＆罠ゾーン右");
                        int zoneIndex = ReadLineNum() - 1;
                        var zone = Player.Field.GetZone(zoneIndex);
                        Player.Place(card, zone);

                        WriteLineResult($"{card.Name}を{zone.Name}に置きました。");
                        break;
                    default:
                        throw new ArgumentException("番号が正しくありません。");
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static int ReadLineNum()
    {
        Console.Write("> ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            throw new ArgumentException("番号が正しくありません");
        }

        return num;
    }

    private static void WriteLineResult(string value)
    {
        Console.Clear();
        Console.WriteLine(value);
    }
}

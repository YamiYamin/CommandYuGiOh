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
                switch (ReadLineNum())
                {
                    case 1:
                        var drawCard = Player.Draw();
                        WriteLineResult($"{drawCard.Name}をドローしました。");
                        break;
                    case 2:
                        if (!Player.Hand.Exists())
                        {
                            WriteLineResult("手札がありません。");
                            break;
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
                    case 3:
                        Console.WriteLine("★ 確認する場所を選んでください。");
                        Console.WriteLine($"1. デッキ, 2. 手札, 3. フィールド, 4. 墓地");
                        switch (ReadLineNum())
                        {
                            case 1:
                                Console.Clear();
                                Player.Deck.PrintDeckList();
                                break;
                            case 2:
                                Console.Clear();
                                Player.Hand.PrintHands();
                                break;
                            case 3:
                                break;
                            case 4:
                                Console.Clear();
                                Player.Graveyard.PrintGraveyardList();
                                break;
                            default:
                                throw new ArgumentException("番号が正しくありません。");
                        }

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

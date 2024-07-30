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
                Console.WriteLine($"★ 操作する場所を選んでください。");
                Console.WriteLine($"1. デッキ, 2. 手札, 3. フィールド, 4. 墓地, 5. 除外");
                switch ((Place)ReadLineNum())
                {
                    case Place.Deck:
                        Console.WriteLine($"★ 操作を選んでください。");
                        Console.WriteLine($"1. ドロー, 2. サーチ, 3. 除外, 4. 確認");
                        switch ((DeckOperation)ReadLineNum())
                        {
                            case DeckOperation.Draw:
                                var drawCard = Player.Draw();
                                WriteLineResult($"{drawCard.Name}をドローしました。");
                                break;
                            case DeckOperation.Search:
                                Console.WriteLine($"★ サーチするカードを選んでください。");
                                Player.Deck.PrintDeckList();
                                int deckIndex = ReadLineNum() - 1;
                                var searchedCard = Player.Search(deckIndex);
                                WriteLineResult($"{searchedCard.Name}をサーチしました。");
                                break;
                            case DeckOperation.Banish:
                                Console.WriteLine($"★ 除外するカードを選んでください。");
                                Player.Deck.PrintDeckList();
                                deckIndex = ReadLineNum() - 1;
                                var banishedCard = Player.BanishFromDeck(deckIndex);
                                WriteLineResult($"{banishedCard.Name}を除外しました。");
                                break;
                            case DeckOperation.Confirmation:
                                Console.Clear();
                                Player.Deck.PrintDeckList();
                                break;
                            default:
                                throw new Exception("番号が正しくありません。");
                        }
                        break;
                    case Place.Hand:
                        Console.WriteLine($"★ 操作を選んでください。");
                        Console.WriteLine($"1. 置く, 2. セット, 3. 確認");
                        switch (ReadLineNum())
                        {
                            case 1:
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
                            case 2:
                                break;
                            case 3:
                                Console.Clear();
                                Player.Hand.PrintHands();
                                break;
                            default:
                                throw new Exception("番号が正しくありません。");
                        }
                        break;
                    case Place.Field:
                        Console.Clear();
                        break;
                    case Place.Graveyard:
                        Console.WriteLine($"★ 操作を選んでください。");
                        Console.WriteLine($"1. , 2. , 3. 確認");
                        switch (ReadLineNum())
                        {
                            case 1:
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                Player.Graveyard.PrintGraveyardList();
                                break;
                            default:
                                throw new Exception("番号が正しくありません。");
                        }
                        break;
                    case Place.BanishedCards:
                        Console.WriteLine($"★ 操作を選んでください。");
                        Console.WriteLine($"1. , 2. , 3. 確認");
                        switch (ReadLineNum())
                        {
                            case 1:
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                Player.BanishedCards.PrintBanishedCards();
                                break;
                            default:
                                throw new Exception("番号が正しくありません。");
                        }
                        break;
                    default:
                        throw new Exception("番号が正しくありません。");
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

    private enum Place
    {
        Deck = 1,
        Hand,
        Field,
        Graveyard,
        BanishedCards
    }

    private enum DeckOperation
    {
        Draw = 1,
        Search,
        Banish,
        Confirmation
    }
}

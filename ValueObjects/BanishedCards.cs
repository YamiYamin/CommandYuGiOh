using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public class BanishedCards : CardListBase
{
    private readonly List<Card> _cards = [];

    public void PrintBanishedCards()
    {
        if (_cards.Count == 0)
        {
            Console.WriteLine("除外されているカードがありません。");
            return;
        }


        Console.Write("除外: ");
        PrintCards(_cards, true);
    }
}

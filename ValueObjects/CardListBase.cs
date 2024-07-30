using YuGiOh.ValueObjects.Cards;

namespace YuGiOh.ValueObjects;

public abstract class CardListBase
{
    protected static void PrintCards<T>(List<T> cards, bool showIndex) where T : Card
    {
        if (showIndex)
        {
            Console.Write($"{1}. {cards.First().Name}");
            for (int i = 2; i < cards.Count + 1; i++)
            {
                Console.Write($", {i}. {cards[i - 1].Name}");
            }
        }
        else
        {
            Console.Write($"{cards.First().Name}");
            for (int i = 1; i < cards.Count; i++)
            {
                Console.Write($", {cards[i].Name}");
            }
        }
        Console.WriteLine();
    }
}

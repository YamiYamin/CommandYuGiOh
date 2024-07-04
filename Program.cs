// See https://aka.ms/new-console-template for more information
using YuGiOh.ValueObjects;

List<Card> cards = 
[
    new Card("0", "灰流うらら", CardType.Monster),
    new Card("0", "増殖するG", CardType.Monster),
    new Card("0", "エフェクト・ヴェーラー", CardType.Monster),
    new Card("0", "融合", CardType.Monster),
    new Card("0", "増援", CardType.Monster),
    new Card("0", "篝火", CardType.Monster),
];

Deck deck = new(cards);

Player player = new(deck, new() { NumOfHands=3 });

player.MainLoop();

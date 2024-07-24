// See https://aka.ms/new-console-template for more information
using YuGiOh.ValueObjects;
using YuGiOh.ValueObjects.Cards;

Deck deck = 
[
    new Monster("0", "灰流うらら"),
    new Monster("0", "増殖するG"),
    new Monster("0", "エフェクト・ヴェーラー"),
    new Monster("0", "融合"),
    new Monster("0", "増援"),
    new Monster("0", "篝火"),
];

var game = new Game(deck, new() { NumOfHands=3 });

game.MainLoop();

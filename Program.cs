// See https://aka.ms/new-console-template for more information
using YuGiOh.ValueObjects;
using YuGiOh.ValueObjects.Cards;

var deck = new Deck(
[
    new Monster("0", "灰流うらら"),
    new Monster("0", "増殖するG"),
    new Monster("0", "エフェクト・ヴェーラー"),
    new Monster("0", "融合"),
    new Monster("0", "増援"),
    new Monster("0", "篝火"),
]);

var options = new DuelOptions()
{
    NumOfHands = 3,
    InitShuffle = true,
};
var game = new Game(deck, options);

game.MainLoop();

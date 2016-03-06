using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePainter painter = new ConsolePainter();

            Deck deck = new Deck();
            deck.Shuffle();

            Hand[] hands = new Hand[4];
            for (int i = 0; i < hands.Length; i++)
                hands[i] = new Hand(deck.Deal(5).ToArray());

            foreach (var hand in hands)
            {
                foreach (var card in hand)
                {
                    painter.Paint(card, true);
                }
                System.Console.WriteLine();
            }

            System.Console.ReadKey();
        }
    }
}

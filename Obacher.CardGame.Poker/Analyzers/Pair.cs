using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class Pair : IAnalyzer
    {
        public int GetRank()
        {
            return 10;
        }

        public bool Analyze(Hand hand)
        {
            return hand.IsPair(1);
        }
    }
}
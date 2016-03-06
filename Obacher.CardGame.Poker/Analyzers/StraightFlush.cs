using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class StraightFlush : IAnalyzer
    {
        public int GetRank()
        {
            return 80;
        }

        public bool Analyze(Hand hand)
        {
            return hand.IsStraight() && hand.IsFlush() && hand.Max(c => c.Value) != CardValueType.Ace;
        }
    }
}
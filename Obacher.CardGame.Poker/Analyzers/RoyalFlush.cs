using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class RoyalFlush : IAnalyzer
    {
        public int GetRank()
        {
            return 90;
        }

        public bool Analyze(Hand hand)
        {
            if (!hand.IsFlush())
                return false;

            if (!hand.IsStraight())
                return false;

            return hand.Max(c => c.Value) == CardValueType.Ace;
        }
    }
}

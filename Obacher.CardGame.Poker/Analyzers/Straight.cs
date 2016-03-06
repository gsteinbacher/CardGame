using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class Straight : IAnalyzer
    {
        public int GetRank()
        {
            return 40;
        }

        public bool Analyze(Hand hand)
        {
            return hand.IsStraight() && !hand.IsFlush();
        }
    }
}
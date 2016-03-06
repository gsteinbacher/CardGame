using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class HighCard : IAnalyzer
    { 
        public int GetRank()
        {
            return 0;
        }

        public bool Analyze(Hand hand)
        {
            // High card always returns true because there cannot be a rank less than that.
            return true;
        }
    }
}
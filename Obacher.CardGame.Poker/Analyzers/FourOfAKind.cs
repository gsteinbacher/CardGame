using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class FourOfAKind : IAnalyzer
    {
        public int GetRank()
        {
            return 70;
        }

        public bool Analyze(Hand hand)
        {
            return hand.IsNofKind(4);
        }
    }
}
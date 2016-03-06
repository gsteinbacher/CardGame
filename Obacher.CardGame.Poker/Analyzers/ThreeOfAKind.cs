using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class ThreeOfAKind : IAnalyzer
    {
        public int GetRank()
        {
            return 30;
        }

        public bool Analyze(Hand hand)
        {
            return hand.IsNofKind(3);
        }
    }
}
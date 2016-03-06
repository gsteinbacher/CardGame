using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class FullHouse : IAnalyzer
    {
        public int GetRank()
        {
            return 60;
        }

        public bool Analyze(Hand hand)
        {
            return hand.GroupBy(c => c.Value).Count() == 2 && hand.IsNofKind(3);
        }
    }
}
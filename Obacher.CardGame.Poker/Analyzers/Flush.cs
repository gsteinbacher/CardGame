using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class Flush : IAnalyzer
    {
        public int GetRank()
        {
            return 50;
        }

        public bool Analyze(Hand hand)
        {
            return hand.IsFlush();
        }
    }
}
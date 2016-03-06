using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public sealed class TwoPair : IAnalyzer
    {
        public int GetRank()
        {
            return 20;
        }

        /// <summary>
        /// Determines if the hand contains two pair.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>True if the hand contains two pair</returns>
        public bool Analyze(Hand hand)
        {
            return hand.IsPair(2);
        }
    }
}
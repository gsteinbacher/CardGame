using System.Linq;
using Obacher.CardGame.Core;
using Obacher.CardGame.Poker.Analyzers;

namespace Obacher.CardGame.Poker
{
    public class AnalyzeCombinations
    {
        private readonly IAnalyzer[] _combinations;

        // Pass in the list of analyzers with the highest value one first
        public AnalyzeCombinations(params IAnalyzer[] combinations)
        {
            // Sort the analyzers so the highest ranked one will be first.
            _combinations = combinations.OrderByDescending(r => r.GetRank()).ToArray();
        }

        public IAnalyzer Analyze(Hand hand)
        {
            return _combinations.FirstOrDefault(combination => combination.Analyze(hand));
        }
    }
}
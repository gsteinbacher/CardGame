using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker.Analyzers
{
    public interface IAnalyzer
    {
        int GetRank();

        bool Analyze(Hand hand);
    }
}

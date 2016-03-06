using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obacher.CardGame.Core;
using Obacher.CardGame.Poker.Analyzers;

namespace Obacher.CardGame.Poker.UnitTest.Analyzers
{
    [TestClass]
    public class HighCardTest
    {
        [TestMethod]
        public void GetRank_WhenCalled_ShouldReturnExpected()
        {
            // Arrange
            const int expected = 0;

            // Act
            var target = new HighCard();
            int actual = target.GetRank();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Check_WhenCalled_ShouldAlwaysReturnTrue()
        {
            // Arrange
            const bool expected = true;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club)
                );

            // Act
            var target = new HighCard();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }
    }
}

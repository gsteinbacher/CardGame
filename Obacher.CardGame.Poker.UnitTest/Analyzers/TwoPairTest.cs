using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obacher.CardGame.Core;
using Obacher.CardGame.Poker.Analyzers;

namespace Obacher.CardGame.Poker.UnitTest.Analyzers
{
    [TestClass]
    public class TwoPairTest
    {
        [TestMethod]
        public void GetRank_WhenCalled_ShouldReturnExpected()
        {
            // Arrange
            const int expected = 20;

            // Act
            var target = new TwoPair();
            int actual = target.GetRank();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Check_WhenFullHouse_ShouldReturnFalse()
        {
            // Arrange
            const bool expected = false;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club),
                new Card(CardValueType.Ace, SuitType.Spade),
                new Card(CardValueType.Ace, SuitType.Heart),
                new Card(CardValueType.Jack, SuitType.Spade),
                new Card(CardValueType.Jack, SuitType.Diamond)
                );

            // Act
            var target = new TwoPair();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Check_WhenTwoPair_ShouldReturnTrue()
        {
            // Arrange
            const bool expected = true;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Heart),
                new Card(CardValueType.Ace, SuitType.Spade),
                new Card(CardValueType.Jack, SuitType.Heart),
                new Card(CardValueType.Jack, SuitType.Spade),
                new Card(CardValueType.Ten, SuitType.Spade)
                );

            // Act
            var target = new TwoPair();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }
    }
}

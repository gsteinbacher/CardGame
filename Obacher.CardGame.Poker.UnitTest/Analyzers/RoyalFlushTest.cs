using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obacher.CardGame.Core;
using Obacher.CardGame.Poker.Analyzers;

namespace Obacher.CardGame.Poker.UnitTest.Analyzers
{
    [TestClass]
    public class RoyalFlushTest
    {
        [TestMethod]
        public void GetRank_WhenCalled_ShouldReturnExpected()
        {
            // Arrange
            const int expected = 90;

            // Act
            var target = new RoyalFlush();
            int actual = target.GetRank();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Check_WhenNotFlush_ShouldReturnFalse()
        {
            // Arrange
            const bool expected = false;
            Hand input = new Hand(
               new Card(CardValueType.Four, SuitType.Diamond),
               new Card(CardValueType.Six, SuitType.Club),
               new Card(CardValueType.Five, SuitType.Club),
               new Card(CardValueType.Eight, SuitType.Club),
               new Card(CardValueType.Seven, SuitType.Club)
               );

            // Act
            var target = new RoyalFlush();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }


        [TestMethod]
        public void Check_WhenNotStraight_ShouldReturnFalse()
        {
            // Arrange
            const bool expected = false;
            Hand input = new Hand(
                new Card(CardValueType.Two, SuitType.Club),
                new Card(CardValueType.Six, SuitType.Club),
                new Card(CardValueType.Five, SuitType.Club),
                new Card(CardValueType.Eight, SuitType.Club),
                new Card(CardValueType.Seven, SuitType.Club)
                );

            // Act
            var target = new RoyalFlush();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Check_WhenStraightFlush_ShouldReturnFalse()
        {
            // Arrange
            const bool expected = false;
            Hand input = new Hand(
                new Card(CardValueType.Four, SuitType.Club),
                new Card(CardValueType.Six, SuitType.Club),
                new Card(CardValueType.Five, SuitType.Club),
                new Card(CardValueType.Eight, SuitType.Club),
                new Card(CardValueType.Seven, SuitType.Club)
                );

            // Act
            var target = new RoyalFlush();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Check_WhenRoyalFlush_ShouldReturnTrue()
        {
            // Arrange
            const bool expected = true;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club),
                new Card(CardValueType.King, SuitType.Club),
                new Card(CardValueType.Queen, SuitType.Club),
                new Card(CardValueType.Jack, SuitType.Club),
                new Card(CardValueType.Ten, SuitType.Club)
            );

            // Act
            var target = new RoyalFlush();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }
    }
}
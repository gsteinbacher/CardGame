using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obacher.CardGame.Core;
using Obacher.CardGame.Poker.Analyzers;

namespace Obacher.CardGame.Poker.UnitTest.Analyzers
{
    [TestClass]
    public class ThreeOfAKindTest
    {
        [TestMethod]
        public void GetRank_WhenCalled_ShouldReturnExpected()
        {
            // Arrange
            const int expected = 30;

            // Act
            var target = new ThreeOfAKind();
            int actual = target.GetRank();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Check_WhenFourOfAKind_ShouldReturnFalse()
        {
            // Arrange
            const bool expected = false;
            Hand input = new Hand(
               new Card(CardValueType.Ace, SuitType.Club),
               new Card(CardValueType.Ace, SuitType.Spade),
               new Card(CardValueType.Ace, SuitType.Heart),
               new Card(CardValueType.Ace, SuitType.Diamond),
               new Card(CardValueType.Ten, SuitType.Spade)
               );

            // Act
            var target = new ThreeOfAKind();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Check_WhenFullHouse_ShouldReturnTrue()
        {
            // Arrange
            const bool expected = true;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club),
                new Card(CardValueType.Ace, SuitType.Spade),
                new Card(CardValueType.Ace, SuitType.Heart),
                new Card(CardValueType.Jack, SuitType.Spade),
                new Card(CardValueType.Jack, SuitType.Diamond)
                );

            // Act
            var target = new ThreeOfAKind();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Check_WhenThreeOfAKind_ShouldReturnTrue()
        {
            // Arrange
            const bool expected = true;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club),
                new Card(CardValueType.Ace, SuitType.Spade),
                new Card(CardValueType.Ace, SuitType.Heart),
                new Card(CardValueType.Jack, SuitType.Spade),
                new Card(CardValueType.Ten, SuitType.Spade)
                );

            // Act
            var target = new ThreeOfAKind();
            bool actual = target.Analyze(input);

            // Assert
            actual.Should().Be(expected);
        }
    }
}

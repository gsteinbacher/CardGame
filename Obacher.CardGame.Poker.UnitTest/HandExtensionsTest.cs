using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obacher.CardGame.Core;
using Obacher.UnitTest.Tools;

namespace Obacher.CardGame.Poker.UnitTest
{
    [TestClass]
    [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    public class HandExtensionsTest
    {
        #region Test IsFlush

        [TestMethod]
        public void IsFlush_WhenNullParameter_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            Hand input = null;

            // Act
            bool actual = input.IsFlush();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void IsFlush_WhenEmptyParameter_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            Hand input = new Hand();

            // Act
            bool actual = input.IsFlush();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void IsFlush_WhenNotFlush_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club),
                new Card(CardValueType.Ace, SuitType.Diamond)
                );

            // Act
            bool actual = input.IsFlush();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void IsFlush_WhenFlush_ShouldReturnTrue()
        {
            // Arrange
            bool expected = true;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club),
                new Card(CardValueType.Two, SuitType.Club)
                );


            // Act
            bool actual = input.IsFlush();

            // Assert
            actual.Should().Be(expected);
        }

        #endregion

        #region Test IsStraight

        [TestMethod]
        public void IsStraight_WhenNullParameter_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            Hand input = null;

            // Act
            bool actual = input.IsStraight();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void IsStraight_WhenEmptyParameter_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            Hand input = new Hand();

            // Act
            bool actual = input.IsStraight();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void IsStraight_WhenNotStraight_ShouldReturnFalse()
        {
            // Arrange
            const bool expected = false;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club),
                new Card(CardValueType.King, SuitType.Club),
                new Card(CardValueType.Jack, SuitType.Club)
            );

            // Act
            bool actual = input.IsStraight();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void IsStraight_WhenStraight_ShouldReturnTrue()
        {
            // Arrange
            const bool expected = true;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club),
                new Card(CardValueType.King, SuitType.Club),
                new Card(CardValueType.Queen, SuitType.Heart),
                new Card(CardValueType.Jack, SuitType.Spade),
                new Card(CardValueType.Ten, SuitType.Spade)
            );

            // Act
            bool actual = input.IsStraight();

            // Assert
            actual.Should().Be(expected);
        }

        #endregion

        #region IsNofKind Tests

        [TestMethod]
        public void IsNofKind_WhenHandIsNull_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            Hand input = null;

            // Act
            bool actual = input.IsNofKind(-1);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void IsNofKind_WhenHandIsEmpty_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            Hand input = new Hand();

            // Act
            bool actual = input.IsNofKind(0);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod, ExceptionExpected(typeof(ArgumentOutOfRangeException), "Number to compare")]
        public void IsNofKind_WhenNumberIsLessThanZeroParameter_ShouldThrowException()
        {
            // Arrange
            Hand input = new Hand(new Card(CardValueType.Ace, SuitType.Club));

            // Act
            input.IsNofKind(-1);

            // Assert
        }

        [TestMethod, ExceptionExpected(typeof(ArgumentOutOfRangeException), "Number to compare")]
        public void IsNofKind_WhenNumberIsZero_ShouldThrowException()
        {
            // Arrange
            Hand input = new Hand(new Card(CardValueType.Ace, SuitType.Club));

            // Act
            input.IsNofKind(0);

            // Assert
        }

        [TestMethod]
        public void IsNofKind_WhenChecking3OfAKind_ShouldReturnTrue()
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
            bool actual = input.IsNofKind(3);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void IsNofKind_WhenChecking4OfAKind_ShouldReturnFalse()
        {
            // Arrange
            const bool expected = false;
            Hand input = new Hand(
                new Card(CardValueType.Ace, SuitType.Club),
                new Card(CardValueType.Ace, SuitType.Spade),
                new Card(CardValueType.Ace, SuitType.Heart),
                new Card(CardValueType.Jack, SuitType.Spade),
                new Card(CardValueType.Ten, SuitType.Spade)
                );

            // Act
            bool actual = input.IsNofKind(4);

            // Assert
            actual.Should().Be(expected);
        }

        #endregion
    }
}

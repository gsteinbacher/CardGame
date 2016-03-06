using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obacher.CardGame.Core;
using Obacher.CardGame.Poker.Analyzers;

namespace Obacher.CardGame.Poker.UnitTest
{
    /// <summary>
    /// Summary description for AnalyzeCombinationsTest
    /// </summary>
    [TestClass]
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    public class AnalyzeCombinationsTest
    {
        [TestMethod]
        public void Analyze_WhenNoAnalyzers_ShouldReturnNull()
        {
            // Arrange
            IAnalyzer expected = null;

            Hand hand = new Hand();

            // Act
            var target = new AnalyzeCombinations();
            var actual = target.Analyze(hand);

            // Assert
            actual.Should().Be(expected);
        }


        [TestMethod]
        public void Analyze_WhenCheckReturnsFalse_ShouldReturnNull()
        {
            // Arrange
            Mock<IAnalyzer> mockAnalyzer = new Mock<IAnalyzer>();
            mockAnalyzer.Setup(m => m.Analyze(It.IsAny<Hand>())).Returns(false);

            IAnalyzer expected = null;

            Hand hand = new Hand();

            // Act
            var target = new AnalyzeCombinations(mockAnalyzer.Object);
            var actual = target.Analyze(hand);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Analyze_WhenHandReturnsTrue_ShouldReturnMockAnalyzer()
        {
            // Arrange
            Mock<IAnalyzer> mockAnalyzer = new Mock<IAnalyzer>();
            mockAnalyzer.Setup(m => m.Analyze(It.IsAny<Hand>())).Returns(true);

            IAnalyzer expected = mockAnalyzer.Object;

            Hand hand = new Hand();

            // Act
            var target = new AnalyzeCombinations(mockAnalyzer.Object);
            var actual = target.Analyze(hand);

            // Assert
            actual.Should().Be(expected);
        }
    }
}

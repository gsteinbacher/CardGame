using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Poker
{
    public static class HandExtensions
    {
        /// <summary>
        /// Determines if the same suit is in every card in the hand
        /// </summary>
        /// <param name="hand">Collection of cards to compare</param>
        /// <returns>True if every card contains the same suit, false if the hand is null or empty or every card in the hand does not contain the same suit</returns>
        internal static bool IsFlush(this Hand hand)
        {
            if (hand == null || !hand.Any())
                return false;

            bool flush = hand.GroupBy(c => c.Suit).Count() == 1;
            return flush;
        }

        /// <summary>
        /// Determines if the value of cards are in a sequence
        /// </summary>
        /// <param name="hand">Collection of cards to compare</param>
        /// <returns>True if the cards are in sequence, false if the hand is null or empty or the values of cards are not in a sequence</returns>
        internal static bool IsStraight(this Hand hand)
        {
            if (hand == null || !hand.Any())
                return false;

            Card[] sortedHand = hand.OrderBy(c => c.Value).ToArray();

            for (int i = 0; i < sortedHand.Length - 1; i++)
            {
                if (sortedHand[i + 1].Value != sortedHand[i].Value + 1)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if the hand has a specified number of the same card.
        /// </summary>
        /// <param name="hand">Collection of cards to compare</param>
        /// <param name="number">Number of cards that should have the same value</param>
        ///     IEnumerable&lt;Card&gt; hand = new[]
        ///         {
        ///             new Card(CardValueType.Ace, SuitType.Club),
        ///             new Card(CardValueType.Ace, SuitType.Spade),
        ///             new Card(CardValueType.Ace, SuitType.Heart),
        ///             new Card(CardValueType.Jack, SuitType.Spade),
        ///             new Card(CardValueType.Ten, SuitType.Spade)
        ///         };
        /// 
        ///     hand.IsNofKind(3);      // Returns true because there are three aces.
        ///     hand.IsNofKind(4);      // Returns false because there is not a four of a kind;
        /// <example>
        /// </example>
        /// <returns>True if the there is the specfied number of cards with the same value</returns>
        internal static bool IsNofKind(this Hand hand, int number)
        {

            if (hand == null || !hand.Any())
                return false;

            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Number to compare should be at least 1.");

            bool isNofKind = hand
                .GroupBy(c => c.Value)
                .Any(g => g.Count() == number);

            return isNofKind;
        }

        /// <summary>
        /// Determines if the specified number of pairs is in the hand
        /// </summary>
        /// <param name="hand">Collection of cards to compare</param>
        /// <param name="number">Number of pairs in the hand</param>
        ///     IEnumerable&lt;Card&gt; hand = new[]
        ///         {
        ///             new Card(CardValueType.Ace, SuitType.Club),
        ///             new Card(CardValueType.Ace, SuitType.Spade),
        ///             new Card(CardValueType.Jack, SuitType.Heart),
        ///             new Card(CardValueType.Jack, SuitType.Spade),
        ///             new Card(CardValueType.Ten, SuitType.Spade)
        ///         };
        /// 
        ///     hand.IsPair(2);      // Returns true because there are two pairs in the hand.
        ///     hand.IsPair(1);      // Returns false because there are two pairs in the hand, not one;
        /// <example>
        /// </example>
        /// <returns>True if the there is the specfied number of cards with the same value</returns>
        internal static bool IsPair(this Hand hand, int number)
        {
            // Group the cards by value
            var groups = hand.GroupBy(c => c.Value);

            // If there is more than two cards that match then the hand is not a pair
            if (groups.Count(c => c.Count() > 2) > 0)
                return false;

            // Returns true if the number of groups specified in the parameters matches the number of groups with a pair
            return groups.Count(c => c.Count() == 2) == number;
        }
    }
}
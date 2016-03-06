using System;
using Obacher.CardGame.Core;

namespace Obacher.CardGame.Console
{
    public class ConsolePainter : IPainter
    {
        public void Paint(Card card, bool frontSide)
        {
            string cardString;
            if (!frontSide)
            {
                cardString = "  ";
            }
            else
            {
                switch (card.Value)
                {
                    case CardValueType.Two:
                        cardString = "2";
                        break;
                    case CardValueType.Three:
                        cardString = "3";
                        break;
                    case CardValueType.Four:
                        cardString = "4";
                        break;
                    case CardValueType.Five:
                        cardString = "5";
                        break;
                    case CardValueType.Six:
                        cardString = "6";
                        break;
                    case CardValueType.Seven:
                        cardString = "7";
                        break;
                    case CardValueType.Eight:
                        cardString = "8";
                        break;
                    case CardValueType.Nine:
                        cardString = "9";
                        break;
                    case CardValueType.Ten:
                        cardString = "T";
                        break;
                    case CardValueType.Jack:
                        cardString = "J";
                        break;
                    case CardValueType.Queen:
                        cardString = "Q";
                        break;
                    case CardValueType.King:
                        cardString = "K";
                        break;
                    case CardValueType.Ace:
                        cardString = "A";
                        break;
                    default:
                        cardString = "";
                        break;
                }

                switch (card.Suit)
                {
                    case SuitType.Club:
                        cardString += "♣";
                        break;
                    case SuitType.Spade:
                        cardString += "♠";
                        break;
                    case SuitType.Heart:
                        cardString += "♥";
                        break;
                    case SuitType.Diamond:
                        cardString += "♦";
                        break;
                }
            }


            System.Console.BackgroundColor = ConsoleColor.Gray;
            if (card.Suit == SuitType.Diamond || card.Suit == SuitType.Heart)
                System.Console.ForegroundColor = ConsoleColor.Red;
            else
                System.Console.ForegroundColor = ConsoleColor.Black;

            System.Console.Write(cardString + ",");
            System.Console.ResetColor();

        }
    }
}
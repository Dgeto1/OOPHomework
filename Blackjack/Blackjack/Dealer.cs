using System;
using System.Collections.Generic;

namespace Blackjack
{
	public class Dealer
	{
        public static List<Card> HiddenCards { get; set; } = new List<Card>();
        public static List<Card> ShowingCards { get; set; } = new List<Card>();

        public static void RevealCard()
        {
            ShowingCards.Add(HiddenCards[0]);
            HiddenCards.RemoveAt(0);
        }

        public static int GetHandValue()
        {
            int value = 0;
            foreach (Card card in ShowingCards)
            {
                value += card.Value;
            }
            return value;
        }

        public static void PrintHand()
        {
            Console.WriteLine($"Dealer's Hand ({GetHandValue()})");
            foreach (Card card in ShowingCards)
            {
                card.WriteDescription();
            }
            for (int i = 0; i < HiddenCards.Count; i++)
            {
                Console.WriteLine("<Second Card>");
            }
            Console.WriteLine();
        }
    }
}
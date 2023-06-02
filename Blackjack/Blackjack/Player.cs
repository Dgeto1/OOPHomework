using System;
using System.Collections.Generic;

namespace Blackjack
{
	public class Player
    {
        public int Chips { get; set; } = 1000;
        public int Bet { get; set; }
        public int Wins { get; set; }
        public int HandsCompleted { get; set; } = 1;

        public List<Card> Hand { get; set; }

        public void AddBet(int bet)
        {
            Bet += bet;
            Chips -= bet;
        }

        public void ClearBet()
        {
            Bet = 0;
        }

        public void ReturnBet()
        {
            Chips += Bet;
            ClearBet();
        }

        public int WinBet(bool blackjack)
        {
            int chipsWon;
            if (blackjack)
            {
                chipsWon = (int)Math.Floor(Bet * 1.5);
            }
            else
            {
                chipsWon = Bet * 2;
            }

            Chips += chipsWon;
            ClearBet();
            return chipsWon;
        }

        public int GetHandValue()
        {
            int value = 0;
            foreach (Card card in Hand)
            {
                value += card.Value;
            }
            return value;
        }

        public void PrintHand()
        {
            Console.Write("Bet: ");
            Console.Write(Bet + "  ");
            Console.Write("Chips: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Chips + "  ");
            Console.Write("Wins: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Wins);
            Console.WriteLine("Round -" + HandsCompleted);

            Console.WriteLine();
            Console.WriteLine($"Your hand ({GetHandValue()}):");
            foreach (Card card in Hand)
            {
                card.WriteDescription();
            }
            Console.WriteLine();
        }
    }
}


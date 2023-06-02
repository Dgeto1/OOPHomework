using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Blackjack;
using Blackjack.Enums;

namespace Blackjack
{
    public class Program
    {
        private static Deck deck = new Deck();
        private static Player player = new Player();

        static void InitializeHands()
        {
            deck.Initialize();

            player.Hand = deck.Hand();
            Dealer.HiddenCards = deck.Hand();
            Dealer.ShowingCards = new List<Card>();

            if (player.Hand[0].Face == Face.Ace && player.Hand[1].Face == Face.Ace)
            {
                player.Hand[1].Value = 1;
            }

            if (Dealer.HiddenCards[0].Face == Face.Ace && Dealer.HiddenCards[1].Face == Face.Ace)
            {
                Dealer.HiddenCards[1].Value = 1;
            }

            Dealer.RevealCard();

            player.PrintHand();
            Dealer.PrintHand();
        }

        static void StartRound()
        {
            Console.Clear();

            if (!TakeBet())
            {
                EndRound(RoundResult.INVALID_BET);
                return;
            }
            Console.Clear();

            InitializeHands();
            TakeActions();

            Dealer.RevealCard();

            Console.Clear();
            player.PrintHand();
            Dealer.PrintHand();

            player.HandsCompleted++;

            if (player.GetHandValue() > 21)
            {
                EndRound(RoundResult.PLAYER_BUST);
                return;
            }

            while (Dealer.GetHandValue() <= 16)
            {
                Dealer.ShowingCards.Add(deck.DrawCard());

                Console.Clear();
                player.PrintHand();
                Dealer.PrintHand();
            }


            if (player.GetHandValue() > Dealer.GetHandValue())
            {
                player.Wins++;
                if (Casino.IsHandBlackjack(player.Hand))
                {
                    EndRound(RoundResult.PLAYER_BLACKJACK);
                }
                else
                {
                    EndRound(RoundResult.PLAYER_WIN);
                }
            }
            else if (Dealer.GetHandValue() > 21)
            {
                player.Wins++;
                EndRound(RoundResult.PLAYER_WIN);
            }
            else if (Dealer.GetHandValue() > player.GetHandValue())
            {
                EndRound(RoundResult.DEALER_WIN);
            }
            else
            {
                EndRound(RoundResult.PUSH);
            }

        }

        static void TakeActions()
        {
            string action;
            do
            {
                Console.Clear();
                player.PrintHand();
                Dealer.PrintHand();

                Console.Write("Enter Action (? for help): ");
                action = Console.ReadLine();

                switch (action.ToUpper())
                {
                    case "HIT":
                        player.Hand.Add(deck.DrawCard());
                        break;
                    case "STAND":
                        break;
                    case "DOUBLE":
                        if (player.Chips <= player.Bet)
                        {
                            player.AddBet(player.Chips);
                        }
                        else
                        {
                            player.AddBet(player.Bet);
                        }
                        player.Hand.Add(deck.DrawCard());
                        break;
                    case "?":
                        Console.WriteLine("Valid Moves:");
                        Console.WriteLine("Hit, Stand, Double");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                }

                if (player.GetHandValue() > 21)
                {
                    foreach (Card card in player.Hand)
                    {
                        if (card.Value == 11)
                        {
                            card.Value = 1;
                            break;
                        }
                    }
                }
            } while (!action.ToUpper().Equals("STAND") && !action.ToUpper().Equals("DOUBLE")
                && !action.ToUpper().Equals("SURRENDER") && player.GetHandValue() <= 21);
        }

        static bool TakeBet()
        {
            Console.Write("Current Chip Count: ");
            Console.WriteLine(player.Chips);

            Console.WriteLine("Minimum Bet: 10");

            Console.Write($"Enter bet to begin hand {player.HandsCompleted}: ");

            string s = Console.ReadLine(); 
            if (Int32.TryParse(s, out int bet) && bet >= Casino.MinimumBet && player.Chips >= bet)
            {
                player.AddBet(bet);
                return true;
            }
            return false;
        }

        static void EndRound(RoundResult result)
        {
            switch (result)
            {
                case RoundResult.PUSH:
                    player.ReturnBet();
                    Console.WriteLine("Player and Dealer Push.");
                    break;
                case RoundResult.PLAYER_WIN:
                    Console.WriteLine($"Player wins {player.WinBet(false)} chips");
                    break;
                case RoundResult.PLAYER_BUST:
                    player.ClearBet();
                    Console.WriteLine("Player Busts");
                    break;
                case RoundResult.PLAYER_BLACKJACK:
                    Console.WriteLine($"Player wins {player.WinBet(true)} chips with Blackjack");
                    break;
                case RoundResult.DEALER_WIN:
                    player.ClearBet();
                    Console.WriteLine("Dealer Wins.");
                    break;
                case RoundResult.INVALID_BET:
                    Console.WriteLine("Invalid Bet.");
                    break;
            }

            if (player.Chips <= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"You ran out of chips! You have played {player.HandsCompleted-1} rounds.");

                Console.WriteLine("Do you want to play again!");

                string command = Console.ReadLine();
                if(command.ToUpper() == "YES")
                {
                    player = new Player();
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            StartRound();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("♠♥♣♦ Welcome to Blackjack ♠♥♣♦");
            Console.WriteLine("Press any key to play.");
            Console.ReadKey();
            StartRound();
        }
    }
}
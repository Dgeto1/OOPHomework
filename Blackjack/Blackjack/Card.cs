using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;

namespace Blackjack
{
    public class Card
    {
        public Suit Suit { get; }
        public Face Face { get; }
        public int Value { get; set; }
        public char Symbol { get; }

        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;

            switch (Suit)
            {
                case Suit.Clubs:
                    Symbol = '♣';
                    break;
                case Suit.Spades:
                    Symbol = '♠';
                    break;
                case Suit.Diamonds:
                    Symbol = '♦';
                    break;
                case Suit.Hearts:
                    Symbol = '♥';
                    break;
            }
            switch (Face)
            {
                case Face.Ten:
                case Face.Jack:
                case Face.Queen:
                case Face.King:
                    Value = 10;
                    break;
                case Face.Ace:
                    Value = 11;
                    break;
                default:
                    Value = (int)Face + 1;
                    break;
            }
        }

        public void WriteDescription()
        {
            if (Face == Face.Ace)
            {
                if (Value == 11)
                {
                    Console.WriteLine($"{Symbol} Soft {Face} of {Suit}");
                }
                else
                {
                    Console.WriteLine($"{Symbol} Hard {Face} of {Suit}");
                }
            }
            else
            {
                Console.WriteLine($"{Symbol} {Face} of {Suit}");
            }

        }
    }
}

using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Cards
{
    public class NumberCard : ICard
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }

        public NumberCard(string suit, string value)
        {
            Suit = suit;
            Value = value;
            Score = GetScore();
        }
        public int GetScore()
        {
            return int.Parse(Value) * GetSuitMultiplier(Suit);
        }

        public static int GetSuitMultiplier(string suit)
        {
            return suit switch
            {
                "C" => 1,
                "D" => 2,
                "H" => 3,
                "S" => 4,
                _ => throw new InvalidOperationException("Invalid input string")
            };
        }
    }
}

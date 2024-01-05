using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Cards
{
    public class JokerCard : ICard
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }

        public JokerCard()
        {
            Suit = "K";
            Value = "J";
            Score = 0;
        }

        public int GetScore() => Score;
    }
}

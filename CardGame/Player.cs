using System;
using System.ComponentModel;
using System.Globalization;
using CardGame.Cards;
using CardGame.Interfaces;

namespace CardGame
{
    public class Player : IPlayer
    {
        public int Score { get; set; }
        public IList<ICard> Hand { get; set; }

        public Player()
        {
            Score = 0;
            Hand = new List<ICard>();
        }
        public void CalculateScore()
        {
            int score = 0;
            int jokerCount = 0;

            foreach (ICard card in Hand)
            {
                if (card is JokerCard)
                {
                    jokerCount++;
                }
                else
                {
                    score += card.Score;
                }
            }

            for (int i = 0; i < jokerCount; i++)
            {
                score *= 2;
            }

            Score = score;
        }


        public void AddCard(ICard card)
        {
            if (card is JokerCard)
            {
                if (Hand.Count(c => c is JokerCard) >= 2)
                {
                    throw new InvalidOperationException("Cannot have more than two Jokers in the hand.");
                }
            }
            else
            {
                if (Hand.Any(c => c.Value == card.Value && c.Suit == card.Suit))
                {
                    throw new InvalidOperationException($"Cards cannot be duplicated. Duplicate card {card.Value}{card.Suit} is not allowed.");
                }
            }

            Hand.Add(card);
        }

        public string GetHand(string hand = "")
        {
            for(int i = 0; i < Hand.Count; i++)
            {
                hand += Hand[i].Value.ToString() + Hand[i].Suit.ToString();
                if (i < Hand.Count - 1)
                {
                    hand += ", ";
                }
            }
            return hand;
        }
    }
}

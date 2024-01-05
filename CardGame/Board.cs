using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CardGame.Interfaces;

namespace CardGame
{
    public class Board : IBoard
    {
        private IPlayer player;
        public Board(IPlayer player)
        {
            this.player = player;
        }

        public void Refresh(Error error)
        {
            Console.Clear();

            Console.Write(RenderScreen(error));

            ResetPlayer();
        }

        public string RenderScreen(Error error = null)
        {
            StringBuilder render = new StringBuilder();
            render.AppendLine("--------------------");
            render.AppendLine("Welcome to the card game!");
            render.AppendLine("--------------------");
            render.AppendLine("Your hand: " + player.GetHand());
            render.AppendLine("--------------------");
            render.AppendLine("Your score: " + player.Score);
            render.AppendLine("--------------------");
            render.AppendLine("Please enter the cards you want to play in the format: 'AH, TD, 7S' (without quotes).");
            render.AppendLine("Valid cards are: 2-9, T, J, Q, K, A for value and H, D, C, S for suit. (each card may only be used once)");
            render.AppendLine("You can also play the Joker card by entering 'JK' which doubles the score (may only be used twice).");
            render.AppendLine("To quit, enter '!quit'.");
            render.AppendLine("--------------------");

            if (error != null)
            {
                render.AppendLine($"Error: {error.Message}");
                render.AppendLine("--------------------");
            }

            render.Append("Input: ");

            return render.ToString();
        }

        public void ResetPlayer()
        {
            player.Hand.Clear();
            player.Score = 0;
        }

        public Error ValidateAction(string input)
        {
            string[] cards = input.ToUpper().Split(',');

            string validRegex = @"^([2-9TJQKA][HDSC])|([JK])";
            foreach (string card in cards)
            {
                if (!Regex.IsMatch(card.Trim(), validRegex))
                {
                    return new Error("Card not recognised: " + card);
                }

                if (card.Trim().Length != 2)
                {
                    return new Error("Invalid input string: " + card);
                }
            }

            foreach (string checkCard in cards)
            {
                    string value = checkCard.Trim().Substring(0, 1);
                    string suit = checkCard.Trim().Substring(1, 1);
                    
                    try
                    {
                        player.AddCard(CardFactory.CreateCard(value, suit));
                    } 
                    catch (InvalidOperationException ex)
                    {
                        player.Hand.Clear();

                        return new Error(ex.Message);
                    }
            }

            return null;
        }
    }
}

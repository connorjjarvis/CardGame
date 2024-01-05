using CardGame;
using CardGame.Cards;
using CardGame.Interfaces;
using System.Numerics;
using System.Text;
namespace CardGame.Tests
{
    public class BoardTests
    {
        private IPlayer player;
        private IBoard board;
        [SetUp]
        public void Setup()
        {
            player = new Player();
            board = new Board(player);
        }

        [Test]
        public void ValidInput()
        {
            board.ValidateAction("2C");
            Assert.AreEqual(1, player.Hand.Count);
        }

        [Test]
        public void InvalidInput()
        {
            Assert.AreEqual("Card not recognised: 2", board.ValidateAction("2").Message);
        }

        [Test]
        public void InvalidCardValue()
        {
            Assert.AreEqual("Card not recognised: X2", board.ValidateAction("X2").Message);
        }

        [Test]
        public void InvalidCardSuit()
        {
            Assert.AreEqual("Card not recognised: 2X", board.ValidateAction("2X").Message);
        }

        [Test]
        public void ResetPlayer()
        {
            board.ResetPlayer();
            Assert.AreEqual(0, player.Hand.Count);
        }

        [Test]
        public void ValidRenderScreen()
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
            render.Append("Input: ");
            Assert.AreEqual(render.ToString(), board.RenderScreen());
        }
        [Test]
        public void ValidRenderScreenWithError()
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
            render.AppendLine("Error: Card not recognised");
            render.AppendLine("--------------------");
            render.Append("Input: ");
            Assert.AreEqual(render.ToString(), board.RenderScreen(new Error("Card not recognised")));
        }

        [Test]
        public void InvalidRenderScreen()
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
            render.AppendLine("Valid cards are: 2-9, T, J, Q, K, A, P for value and H, D, C, S for suit. (each card may only be used once)");
            render.AppendLine("You can also play the Joker card by entering 'JK' which doubles the score (may only be used twice).");
            render.AppendLine("To quit, enter '!quit'.");
            render.AppendLine("--------------------");
            render.Append("Input: ");
            Assert.AreNotEqual(render.ToString(), board.RenderScreen());
        }

        [Test]
        public void ValidAction() {
            Assert.AreEqual(null, board.ValidateAction("2C"));
        }

        [Test]
        public void InvalidCard_ResetPlayerHand()
        {
            Error error = board.ValidateAction("2X");
            Assert.AreEqual(0, player.Hand.Count);
            Assert.AreEqual("Card not recognised: 2X", error.Message);
        }
    }
}
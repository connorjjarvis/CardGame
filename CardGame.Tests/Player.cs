using CardGame;
using CardGame.Cards;
using CardGame.Interfaces;
using System.Numerics;
namespace CardGame.Tests
{
    public class PlayerTests
    {
        private IPlayer player;
        [SetUp]
        public void Setup()
        {
            player = new Player();
        }

        
        [Test]
        public void DuplicateCard()
        {
            player.AddCard(CardFactory.CreateCard("2", "C"));
            Assert.Throws<InvalidOperationException>(() => player.AddCard(CardFactory.CreateCard("2", "C")));
        }

        [Test]
        public void ValidDoubleJoker()
        {
            player.AddCard(CardFactory.CreateCard("J", "K"));
            player.AddCard(CardFactory.CreateCard("J", "K"));
            Assert.AreEqual(2, player.Hand.Count(t => t.Value == "J" && t.Suit == "K"));
        }

        [Test]
        public void InvalidTripleJoker()
        {
            player.AddCard(CardFactory.CreateCard("J", "K"));
            player.AddCard(CardFactory.CreateCard("J", "K"));
            Assert.Throws<InvalidOperationException>(() => player.AddCard(CardFactory.CreateCard("J", "K")));
        }

        [Test]
        public void ValidNumberCardScore()
        {
            player.AddCard(CardFactory.CreateCard("2", "C"));
            Assert.AreEqual(2, player.Hand.First(t => t.Value == "2" && t.Suit == "C").Score);
        }

        [Test]
        public void ValidFaceCardScore()
        {
            player.AddCard(CardFactory.CreateCard("J", "C"));
            Assert.AreEqual(11, player.Hand.First(t => t.Value == "J" && t.Suit == "C").Score);

        }

        [Test]
        public void ValidFaceCard_GetScore()
        {
            player.AddCard(CardFactory.CreateCard("J", "C"));
            Assert.AreEqual(11, player.Hand.First(t => t.Value == "J" && t.Suit == "C").GetScore());
        }

        [Test]
        public void ValidJokerCardScore()
        {
            player.AddCard(CardFactory.CreateCard("J", "K"));
            Assert.AreEqual(0, player.Hand.First(t => t.Value == "J" && t.Suit == "K").Score);
        }

        [Test]
        public void ValidJokerCardMultipler()
        {
            player.AddCard(CardFactory.CreateCard("J", "K"));
            player.AddCard(CardFactory.CreateCard("A", "C"));
            player.CalculateScore();
            Assert.AreEqual(28, player.Score);
        }

        [Test]
        public void ValidNumberCardSuitMultiplier()
        {
            player.AddCard(CardFactory.CreateCard("2", "H"));
            Assert.AreEqual(6, player.Hand.First(t => t.Value == "2" && t.Suit == "H").Score);
        }

        [Test]
        public void ValidFaceCardSuitMultiplier()
        {
            player.AddCard(CardFactory.CreateCard("J", "C"));
            Assert.AreEqual(11, player.Hand.First(t => t.Value == "J" && t.Suit == "C").Score);
        }

        [Test]
        public void ValidPlayerHand()
        {
           player.AddCard(CardFactory.CreateCard("2", "C"));
           player.AddCard(CardFactory.CreateCard("J", "C"));
           Assert.AreEqual("2C, JC", player.GetHand());
        }

    }
}
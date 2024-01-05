using CardGame;
using CardGame.Cards;
using CardGame.Interfaces;
using System.Numerics;
namespace CardGame.Tests
{
    public class CardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        public static IEnumerable<TestCaseData> ValidNumberCardData
        {
            get
            {
                yield return new TestCaseData("2", "C");
                yield return new TestCaseData("3", "C");
                yield return new TestCaseData("4", "C");
                yield return new TestCaseData("5", "C");
                yield return new TestCaseData("6", "C");
                yield return new TestCaseData("7", "C");
                yield return new TestCaseData("8", "C");
                yield return new TestCaseData("9", "C");
                yield return new TestCaseData("2", "D");
                yield return new TestCaseData("3", "D");
                yield return new TestCaseData("4", "D");
                yield return new TestCaseData("5", "D");
                yield return new TestCaseData("6", "D");
                yield return new TestCaseData("7", "D");
                yield return new TestCaseData("8", "D");
                yield return new TestCaseData("9", "D");
                yield return new TestCaseData("2", "H");
                yield return new TestCaseData("3", "H");
                yield return new TestCaseData("4", "H");
                yield return new TestCaseData("5", "H");
                yield return new TestCaseData("6", "H");
                yield return new TestCaseData("7", "H");
                yield return new TestCaseData("8", "H");
                yield return new TestCaseData("9", "H");
                yield return new TestCaseData("2", "S");
                yield return new TestCaseData("3", "S");
                yield return new TestCaseData("4", "S");
                yield return new TestCaseData("5", "S");
                yield return new TestCaseData("6", "S");
                yield return new TestCaseData("7", "S");
                yield return new TestCaseData("8", "S");
                yield return new TestCaseData("9", "S");
            }
        }

        public static IEnumerable<TestCaseData> ValidFaceCardData
        {
            get
            {
                yield return new TestCaseData("A", "C");
                yield return new TestCaseData("T", "C");
                yield return new TestCaseData("Q", "C");
                yield return new TestCaseData("K", "C");
                yield return new TestCaseData("J", "C");
                yield return new TestCaseData("A", "D");
                yield return new TestCaseData("T", "D");
                yield return new TestCaseData("Q", "D");
                yield return new TestCaseData("K", "D");
                yield return new TestCaseData("J", "D");
                yield return new TestCaseData("A", "H");
                yield return new TestCaseData("T", "H");
                yield return new TestCaseData("Q", "H");
                yield return new TestCaseData("K", "H");
                yield return new TestCaseData("J", "H");
                yield return new TestCaseData("A", "S");
                yield return new TestCaseData("T", "S");
                yield return new TestCaseData("Q", "S");
                yield return new TestCaseData("K", "S");
                yield return new TestCaseData("J", "S");
            }
        }

        [Test]
        public void ValidNumberCard()
        {
            ICard card = CardFactory.CreateCard("2", "C");
            Assert.AreEqual(typeof(NumberCard), card.GetType());
            Assert.IsTrue(card.Score == 2);
        }

        [Test]
        public void ValidFaceCard()
        {
            ICard card = CardFactory.CreateCard("J", "C");
            Assert.AreEqual(typeof(FaceCard), card.GetType());
            Assert.IsTrue(card.Score == 11);
        }

        [Test]
        public void ValidJokerCard()
        {
            ICard card = CardFactory.CreateCard("J", "K");
            Assert.AreEqual(typeof(JokerCard), card.GetType());
            Assert.IsTrue(card.Score == 0);
        }

        [Test]
        public void InvalidCard()
        {
            Assert.Throws<ArgumentException>(() => CardFactory.CreateCard("12", "U"));
        }

        [Test]
        public void InvalidCardValue()
        {
            Assert.Throws<ArgumentException>(() => CardFactory.CreateCard("X", "C"));
        }

        [Test]
        public void InvalidCardSuit()
        {
            Assert.Throws<InvalidOperationException>(() => CardFactory.CreateCard("2", "X"));
        }

        [Test]
        public void InvalidFaceCardSuitAndValue()
        {
            Assert.Throws<InvalidOperationException>(() => CardFactory.CreateCard("A", "X"));
        }
        [Test]
        public void InvalidFaceCard_GetScore()
        {
            Assert.Throws<InvalidOperationException>(() => CardFactory.CreateCard("A", "X"));
        }

        [Test]
        public void ValidFaceCard_GetScore()
        {
            ICard _faceCard = CardFactory.CreateCard("J", "C");
            Assert.AreEqual(11, _faceCard.GetScore());
        }

        [Test]
        public void ValidNumberCard_GetScore()
        {
            ICard _numberCard = CardFactory.CreateCard("2", "C");
            Assert.AreEqual(2, _numberCard.GetScore());
        }

        [Test]
        public void ValidJokerCard_GetScore()
        {
            ICard _jokerCard = CardFactory.CreateCard("J", "K");
            Assert.AreEqual(0, _jokerCard.GetScore());
        }

        [Test]
        public void ValidSuitMultiplier()
        {
            Assert.AreEqual(1, FaceCard.GetSuitMultiplier("C"));
            Assert.AreEqual(2, FaceCard.GetSuitMultiplier("D"));
            Assert.AreEqual(3, FaceCard.GetSuitMultiplier("H"));
            Assert.AreEqual(4, FaceCard.GetSuitMultiplier("S"));
            Assert.AreEqual(1, NumberCard.GetSuitMultiplier("C"));
            Assert.AreEqual(2, NumberCard.GetSuitMultiplier("D"));
            Assert.AreEqual(3, NumberCard.GetSuitMultiplier("H"));
            Assert.AreEqual(4, NumberCard.GetSuitMultiplier("S"));
        }


        [Test, TestCaseSource("ValidNumberCardData")]
        public void ValidNumberCardClubType(string value, string suit)
        {
            Assert.AreEqual(typeof(NumberCard), CardFactory.CreateCard(value, suit).GetType());
        }


        [Test, TestCaseSource("ValidFaceCardData")]
        public void ValidFaceCardClubType(string value, string suit)
        {
            Assert.AreEqual(typeof(FaceCard), CardFactory.CreateCard(value, suit).GetType());
        }

    }
}
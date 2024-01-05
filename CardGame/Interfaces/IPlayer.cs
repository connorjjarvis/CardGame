namespace CardGame.Interfaces
{
    public interface IPlayer
    {
        int Score { get; set; }
        IList<ICard> Hand { get; set; }

        string GetHand(string hand = "");
        void AddCard(ICard card);
        void CalculateScore();
    }
}
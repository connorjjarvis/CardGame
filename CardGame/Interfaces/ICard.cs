namespace CardGame.Interfaces
{
    public interface ICard
    {
        string Suit { get; set; }
        string Value { get; set; }
        int Score { get; set; }

        int GetScore();
    }
}

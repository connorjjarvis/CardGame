using CardGame.Cards;
using CardGame.Interfaces;

public static class CardFactory
{
    public static ICard CreateCard(string value, string suit = "")
    {
        if (value == "J" && suit == "K")
        {
            return new JokerCard();
        }

        return value switch
        {
            "T" or "J" or "Q" or "K" or "A" => new FaceCard(suit, value),
            "2" or "3" or "4" or "5" or "6" or "7" or "8" or "9" => new NumberCard(suit, value),
            _ => throw new ArgumentException("Invalid card")
        };
    }
}
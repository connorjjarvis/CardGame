using static System.Formats.Asn1.AsnWriter;

namespace CardGame.Interfaces
{
    public interface IBoard 
    {
        void Refresh(Error error);
        string RenderScreen(Error error = null);
        void ResetPlayer();
        Error ValidateAction(string input);

    }
}

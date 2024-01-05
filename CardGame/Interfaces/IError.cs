using static System.Formats.Asn1.AsnWriter;

namespace CardGame.Interfaces
{
    public interface IError
    {
        string Message { get; set; }
    }
}

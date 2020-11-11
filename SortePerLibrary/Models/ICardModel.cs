namespace SortePerLibrary.Models
{
    /// <summary>
    /// This is the base class for all cards types
    /// </summary>
    public interface ICardModel
    {
        CardValue CardValue { get; set; }
    }
}
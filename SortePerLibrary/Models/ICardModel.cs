using System;

namespace SortePerLibrary.Models
{
    /// <summary>
    /// This is the base class for all cards types
    /// </summary>
    public interface ICardModel
    {
        Enum CardValue { get; set; }
    }
}
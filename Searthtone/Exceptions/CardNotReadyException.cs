using System;
namespace Searthtone.Exceptions
{
    public class CardNotReadyException : Exception
    {
        public CardNotReadyException() : base("Card Not Exception")
        {
        }

        public CardNotReadyException(string message) : base(message)
        {
        }
    }
}

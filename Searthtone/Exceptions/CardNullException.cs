using System;
namespace Searthtone.Exceptions
{
    public class CardNullException : Exception
    {
        public CardNullException() : base("Card Null")
        {
        }

        public CardNullException(string message) : base(message)
        {
        }
    }
}

using System;
namespace Searthtone.Exceptions
{
    public class InsufficientManaException : Exception
    {
        public InsufficientManaException() : base("Insufficient Mana")
        {
        }

        public InsufficientManaException(string message) : base(message)
        {
        }
    }
}

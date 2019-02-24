using System;
namespace Searthtone.Exceptions
{
    public class PlayerCardCollectionUnderflowException : Exception
    {
        public PlayerCardCollectionUnderflowException(): base("Player Card Collection Underflow (min 10)")
        {
        }

        public PlayerCardCollectionUnderflowException(string message) : base(message)
        {
        }
    }
}

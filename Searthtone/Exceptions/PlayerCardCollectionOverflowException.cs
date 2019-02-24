using System;
namespace Searthtone.Exceptions
{
    public class PlayerCardCollectionOverflowException : Exception
    {
        public PlayerCardCollectionOverflowException(): base("Player Card Collection Overflow (max 15)")
        {
        }

        public PlayerCardCollectionOverflowException(string message) : base(message)
        {
        }
    }
}

using System;
namespace Searthtone.Exceptions
{
    public class PlayerCardCollectionNullException : Exception
    {
        public PlayerCardCollectionNullException(): base("Player Card Collection Null")
        {
        }

        public PlayerCardCollectionNullException(string message) : base(message)
        {
        }
    }
}

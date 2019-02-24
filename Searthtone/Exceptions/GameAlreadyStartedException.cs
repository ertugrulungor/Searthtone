using System;
namespace Searthtone.Exceptions
{
    public class GameAlreadyStartedException : Exception
    {
        public GameAlreadyStartedException() : base("Game already started")
        {
        }

        public GameAlreadyStartedException(string message) : base(message)
        {
        }
    }
}

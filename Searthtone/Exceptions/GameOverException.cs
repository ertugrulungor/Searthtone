using System;

namespace Searthtone.Exceptions
{
    public class GameOverException : Exception
    {
        public GameOverException() : base("Game Over")
        {

        }

        public GameOverException(string message) : base(message)
        {

        }
    }
}

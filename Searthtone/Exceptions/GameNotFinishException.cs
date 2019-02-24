using System;
namespace Searthtone.Exceptions
{
    public class GameNotFinishException : Exception
    {
        public GameNotFinishException() : base("Game Not Finish")
        {
        }

        public GameNotFinishException(string message) : base(message)
        {
        }
    }
}

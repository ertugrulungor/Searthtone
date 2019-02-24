using System;
namespace Searthtone.Exceptions
{
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException() : base("Invalid Move")
        {
        }

        public InvalidMoveException(string message) : base(message)
        {
        }
    }
}

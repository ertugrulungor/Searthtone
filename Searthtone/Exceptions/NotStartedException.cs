using System;
namespace Searthtone.Exceptions
{
    public class NotStartedException : Exception
    {
        public NotStartedException() : base("Game Not Started")
        {

        }

        public NotStartedException(string message) : base(message)
        {

        }
    }
}

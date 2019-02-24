using System;
namespace Searthtone.Exceptions
{
    public class PickedCardsNotContainsThisCardException : Exception
    {
        public PickedCardsNotContainsThisCardException() : base("Picked Cards Not Contains This Card")
        {
        }

        public PickedCardsNotContainsThisCardException(string message) : base(message)
        {
        }
    }
}

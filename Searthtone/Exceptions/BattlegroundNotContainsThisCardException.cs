using System;
namespace Searthtone.Exceptions
{
    public class BattlegroundNotContainsThisCardException: Exception
    {
        public BattlegroundNotContainsThisCardException() : base("Battlefield Not Contains This Card")
        {
        }

        public BattlegroundNotContainsThisCardException(string message) : base(message)
        {
        }
    }
}

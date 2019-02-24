using System;
using System.Collections.Generic;

namespace Searthtone.Core
{
    public interface ICardService
    {
        List<Card> Attack(Card opponent);
    }
}

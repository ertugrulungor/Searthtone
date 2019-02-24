using System;
using Searthtone.Type;

namespace Searthtone
{
    internal static class Context
    {

        static Context()
        {
            GameState = GameStateType.Ready;
        }

        internal static Face PlayerOne { get; set; }
        internal static Face PlayerTwo { get; set; }
        internal static GameStateType GameState { get; set; }
        internal static PlayerType NextTurn { get; set; }
        internal static BattleGround BattleGround { get; set; }
        internal static int NumberOfTurn { get; set; }
        internal static PlayerType Winner { get; set; }
    }
}

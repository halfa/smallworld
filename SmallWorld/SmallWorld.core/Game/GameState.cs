using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the serializable game states.
    /// </summary>
    [Serializable]
    public class GameState
    {
        /// <summary>
        /// Constructor for the GameState class.
        /// </summary>
        public GameState()
        {
            turnCounter = 0;
            activePlayerIndex = 0;
            players = new List<Player>();
            selectedUnit = null;
        }

        /// <summary>
        /// Memberwise constructor for the GameState class.
        /// </summary>
        /// <param name="s"></param>
        public GameState(GameState s)
        {
            turnCounter = s.turnCounter;
            activePlayerIndex = s.activePlayerIndex;

            players = new List<Player>();
            foreach (Player p in s.players)
                players.Add(new Player(p));

            selectedUnit = null;
        }

        /// <summary>
        /// Read and write access to the current gameState's activePlayerIndex field.
        /// </summary>
        public int activePlayerIndex { get; set; }

        /// <summary>
        /// Read and write access to the current gameState's players field.
        /// </summary>
        public List<Player> players { get; set; }

        /// <summary>
        /// Read and write access to the current gameState's selectedUnit field.
        /// </summary>
        public AUnit selectedUnit { get; set; }

        /// <summary>
        /// Read and write access to the current gameState's turnCounter field.
        /// </summary>
        public int turnCounter { get; set; }
    }
}
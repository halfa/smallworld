using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the serializable game data.
    /// </summary>
    [Serializable]
    public class GameData
    {
        /// <summary>
        /// Read and write access to the current gameData's mapData field.
        /// </summary>
        public MapData mapData { get; set; }

        /// <summary>
        /// Read and write access to the current gameData's gameSettings field.
        /// </summary>
        public GameSettings gameSettings { get; set; }

        /// <summary>
        /// Read and write access to the current gameData's currentState field.
        /// </summary>
        public GameState currentState { get; set; }

        /// <summary>
        /// Read and write access to the current gameData's previousGameStates field.
        /// </summary>
        public Stack<GameState> previousGameStates { get; set; }

        /// <summary>
        /// Read and write access to the current gameData's orderedPlayersData field.
        /// </summary>
        public List<PlayerData> orderedPlayersData { get; set; }

        /// <summary>
        /// Constructor for the GameData class.
        /// </summary>
        public GameData()
        {
            mapData = new MapData();
            gameSettings = new GameSettings();
            currentState = new GameState();
            previousGameStates = new Stack<GameState>();
            orderedPlayersData = new List<PlayerData>();
        }
        
    }
}
using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    public class Game : ISavable
    {
        public Game(GameSettings settings)
        {
            gameSettings = settings;
        }

        /// <summary>
        /// Constructor for the Game class using the specified gameData to recreate the game.
        /// </summary>
        /// <param name="mapData"></param>
        public Game(GameData data)
        {
            currentState = data.currentState;
            gameSettings = data.gameSettings;
            map = new Map(data.mapData);
            orderedPlayers = new List<Player>();
            foreach (PlayerData p in data.orderedPlayersData)
                orderedPlayers.Add(new Player(p));
            previousGameStates = data.previousGameStates;
        }

        public GameSettings gameSettings { get; set; }

        public GameState currentState { get; set; }

        public Stack<GameState> previousGameStates { get; set; }

        public Map map { get; set; }

        public List<Player> orderedPlayers { get; set; }

        public int countPoints(Player player)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Terminates the current player's turn
        /// </summary>
        public void endGameTurn()
        {
            throw new System.NotImplementedException();
        }

        public Player getActivePlayer()
        {
            throw new System.NotImplementedException();
        }

        public void undo()
        {
            throw new System.NotImplementedException();
        }

        public bool isGameOver()
        {
            throw new System.NotImplementedException();
        }

        public void saveData(string filePath)
        {
            throw new NotImplementedException();
        }

        public void loadData(string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the serializable data object representing the current game.
        /// </summary>
        /// <returns></returns>
        public GameData toData()
        {
            GameData data = new GameData();

            data.currentState = currentState;
            data.gameSettings = gameSettings;
            data.mapData = map.toData();
            foreach (Player p in orderedPlayers)
                data.orderedPlayersData.Add(p.toData());
            data.previousGameStates = previousGameStates;

            return data;
        }

        /// <summary>
        /// Stacks the current game state onto the previous game states stack.
        /// The stored data is a memberwise copy of the current state data.
        /// </summary>
        public void stack()
        {
            GameState toStack = new GameState(currentState);
            previousGameStates.Push(toStack);
        }

        public bool isSelectedUnitMovableTo(Position position)
        {
            throw new System.NotImplementedException();
        }

        public AUnit selectUnitAt(Position position)
        {
            throw new System.NotImplementedException();
        }

        public void moveSelectedUnitTo(Position position)
        {
            throw new System.NotImplementedException();
        }

        public void endPlayerTurn(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}

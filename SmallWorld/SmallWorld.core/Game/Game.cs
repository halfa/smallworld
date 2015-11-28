using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable()]
    public class Game : ISavable
    {
        public Game(GameSettings settings)
        {
            gameSettings = settings;
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

        public GameData toData()
        {
            throw new System.NotImplementedException();
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

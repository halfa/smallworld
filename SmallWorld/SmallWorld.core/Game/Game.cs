using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable()]
    public class Game : ISavable
    {
        private GameSettings _gameSettings;
        private GameState _currentState;
        private System.Collections.Generic.Stack<GameState> _previousGameStates;
        private Map _map;
        private Player[] _orderedPlayers;

        public Game(GameSettings settings)
        {
            gameSettings = settings;
        }

        public GameSettings gameSettings
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public GameState currentState
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Stack<GameState> previousGameStates
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Map map
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<Player> orderedPlayers
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

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

        public void stack()
        {
            throw new System.NotImplementedException();
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

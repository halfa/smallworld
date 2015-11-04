using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable()]
    public class Game : ISavable
    {
        private GameSettings _settings;
        private GameState _currentState;
        private System.Collections.Generic.Stack<GameState> _previousGameStates;
        private Map _map;
        private Player[] _orderedPlayers;
        private SmallWorld _smallWorld;
        private GameData _gameData;

        public Game(int nbPlayers, int nbTurns, int nbUnits)
        {
            throw new System.NotImplementedException();
        }

        public GameSettings settings
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

        public Player[] orderedPlayers
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public SmallWorld smallWorld
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public GameData gameData
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
        public void endTurn()
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
    }
}

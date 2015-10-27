using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class Game
    {
        private readonly int _turnLimit;
        private readonly int _unitLimit;
        private Array _board;
        private List<Player> _players;
        private int _turnCounter;
        private SmallWorld.Core.IMap _map;

        public Game(int nbPlayers, int nbTurns, int nbUnits)
        {
            throw new System.NotImplementedException();
        }

        ~Game()
        {
            throw new System.NotImplementedException();
        }
    
        public List<SmallWorld.Core.Player> players
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IMap map
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Player[] getTurnOrder()
        {
            throw new System.NotImplementedException();
        }

        public int countPoints(Player player)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Undo the last move
        /// </summary>
        public void undo()
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

        public Player getCurrentPlayer()
        {
            throw new System.NotImplementedException();
        }
    }
}

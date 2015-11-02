using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class GameState
    {
        private int _turnCounter;
        private Dictionary<Position, List<AUnit>> _positionsUnits;
        private Player _activePlayer;
        private IMap _map;
        private List<Player> _players;

        public int turnCounter
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Dictionary<Position, List<AUnit>> positionsUnits
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Player activePlayer
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

        public List<Player> players
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
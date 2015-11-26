using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable]
    public class GameState
    {
        private int _turnCounter;
        private Dictionary<Position, List<AUnit>> _positionsUnits;
        private int _activePlayerIndex;
        private List<Player> _players;
        private AUnit _selectedUnit;

        public GameState()
        {
            throw new System.NotImplementedException();
        }

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

        public int activePlayerIndex
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

        public AUnit selectedUnit
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class GameState : ISavable
    {
        private int _turnCounter;
        private Dictionary<Position, List<AUnit>> _positionsUnits;
        private int _activePlayerIndex;
        private Dictionary<Player, List<AUnit>> _playersUnits;

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

        public Dictionary<Player, List<AUnit>> playersUnits
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public System.SerializableAttribute toData()
        {
            throw new NotImplementedException();
        }

        public void loadData(System.SerializableAttribute data)
        {
            throw new System.NotImplementedException();
        }
    }
}
﻿using System;
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
        private Dictionary<Player, List<AUnit>> _playersUnits;

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
    }
}
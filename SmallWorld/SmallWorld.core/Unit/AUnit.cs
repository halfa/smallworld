﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable]
    public abstract class AUnit
    {
        private float _actionPool;
        private int _healthPt;
        private int _attackPt;
        private int _defencePt;
        private int _range;
        private Position _position;

        public Position position
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void move(Position position)
        {
            throw new System.NotImplementedException();
        }

        public void attack(Position defenderPos)
        {
            /*
            This method should update the life and eventually kill state of BOTH INVOLVED UNITS.
            */
            throw new System.NotImplementedException();
        }

        public abstract int countPoints();

        public bool loseHP(int amount)
        {
            throw new System.NotImplementedException();
        }

        public abstract bool canCrossTile(ATile tile);
    }
}

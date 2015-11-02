using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public abstract class AUnit
    {
        private float _actionPool;
        private int _healthPt;
        private int _attackPt;
        private int _defencePt;
        private int _range;
        private Player _player;
        private Position _position;

        public Player player
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

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

        public void attack(AUnit defender)
        {
            /*
            This method should update the life and eventually kill state of BOTH INVOLVED UNITS.
            */
            throw new System.NotImplementedException();
        }

        public abstract int countPoints();
    }
}

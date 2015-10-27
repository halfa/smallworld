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

        public void move()
        {
            throw new System.NotImplementedException();
        }

        public void attack()
        {
            throw new System.NotImplementedException();
        }
    }
}

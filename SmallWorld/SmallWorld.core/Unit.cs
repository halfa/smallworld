using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public abstract class Unit
    {
        private float actionPool;
        private int healthPt;
        private int attackPt;
        private int defencePt;
        private int range;

        public Player Player
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

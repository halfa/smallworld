using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public abstract class Unit
    {
        private float actionPool;
        private int life;
        private int attack;
        private int defence;
        private int range;
    
        public Tile Tile
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

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
    }
}

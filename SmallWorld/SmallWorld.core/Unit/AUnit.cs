using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable]
    public abstract class AUnit
    {
        public double actionPool { get; set; }

        public int attackPt { get; set; }

        public int defencePt { get; set; }

        public int healthPt { get; set; }

        public Position position { get; set; }

        public int range { get; set; }

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

        public void loseHP(int amount)
        {
            healthPt -= amount;
            if (healthPt < 0)
                healthPt = 0;
        }

        public bool isDead()
        {
            return healthPt == 0;
        }

        public abstract bool canCrossTile(ATile tile);

        public abstract int countPoints(ATile tile);

        public abstract double getMoveCost(ATile aimedTile);

        public abstract int getAttackRange(ATile currentTile);
    }
}

using System;
using System.Xml.Serialization;

namespace SmallWorld.Core
{
    /// <summary>
    /// The AUnit class is an asbtract tempplate for game Units.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(ElfUnit))]
    [XmlInclude(typeof(HumanUnit))]
    [XmlInclude(typeof(OrcUnit))]
    public abstract class AUnit
    {
        /// <summary>
        /// This property represents the current unit's remaining action points.
        /// </summary>
        public double actionPool { get; set; }

        /// <summary>
        /// This property represents the current unit's attack points.
        /// </summary>
        public int attackPt { get; set; }

        /// <summary>
        /// This property represents the current unit's defence points.
        /// </summary>
        public int defencePt { get; set; }

        /// <summary>
        /// This property represents the current unit's current health.
        /// </summary>
        public int healthPt { get; set; }

        /// <summary>
        /// This property represents the current unit's position on the map.
        /// </summary>
        public Position position { get; set; }

        /// <summary>
        /// This property represents the current unit's default range.
        /// To get the current range, based on the unit's position, use the getAttackRange(ATile t) method.
        /// </summary>
        public int range { get; set; }

        /// <summary>
        /// This method performs the attack of the current unit at the specified enemy unit.
        /// The defender unit will lose health points as well as defence points, since it sustained an attack.
        /// </summary>
        /// <param name="defenderPos"></param>
        public void attack(AUnit defender)
        {
            Random rd = new Random();
            double ratio = (rd.Next() % 30) / 100;
            int attack = (int)(attackPt * (0.7 + ratio));
            // 4% chance of critical strike because lucky hit. //
            int crit = rd.Next() % 25;
            if (crit == 1)
                attackPt = attackPt * 2;
            defender.loseHP(attack - defender.defencePt);
            int remainingDefence = defender.defencePt - 1;
            if (remainingDefence >= 0)
                defender.defencePt = remainingDefence;

        }

        /// <summary>
        /// This method updates the current unit's health points, lowering them by the specified amount.
        /// If the current unit loses more health points than it has, its health points are set to 0.
        /// If the current unit has a lucky defence, it shall not lose any defence points.
        /// </summary>
        /// <param name="amount"></param>
        public void loseHP(int amount)
        {
            // 1% chance of not losing health because lucky miss. //
            Random rd = new Random();
            int crit = rd.Next() % 100;
            if (crit == 1)
            {
                defencePt++;
                return;
            }
            if (amount < 0)
                amount = 0;
            healthPt -= amount;
            if (healthPt < 0)
                healthPt = 0;
        }

        /// <summary>
        /// Determines if the current unit is dead, ie has no health points left.
        /// </summary>
        /// <returns></returns>
        public bool isDead()
        {
            return healthPt == 0;
        }

        /// <summary>
        /// Restores the action pool the the current unit to its default value.
        /// </summary>
        public void restoreActionPool()
        {
            actionPool = 2;
        }

        /// <summary>
        /// Deetermines if the curren unit can cross the specified tile, only regarding its type.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public abstract bool canCrossTile(ATile tile);

        /// <summary>
        /// Computes the number of points that the curren unit might provide to its player owner.
        /// This value may not be used if several units are located on the same tile.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public abstract int countPoints(ATile tile);

        /// <summary>
        /// Computes the cost of moving from the current position to the specified type of tile.
        /// </summary>
        /// <param name="aimedTile"></param>
        /// <returns></returns>
        public abstract double getMoveCost(ATile aimedTile);

        /// <summary>
        /// Determines the current unit's attack range, regarding the specified tile.
        /// The said tile is know to be the unit's current tile.
        /// </summary>
        /// <param name="currentTile"></param>
        /// <returns></returns>
        public abstract int getAttackRange(ATile currentTile);

        /// <summary>
        /// Determines the current unit's race.
        /// </summary>
        /// <returns></returns>
        public abstract Races getRace();

        /// <summary>
        /// Determines if the specified unit has the same fields' values than the current unit.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool equals(AUnit unit)
        {
            if (unit.getRace() != this.getRace())
                return false;
            bool res = true;
            res = res && (actionPool == unit.actionPool);
            res = res && (attackPt == unit.attackPt);
            res = res && (defencePt == unit.defencePt);
            res = res && (healthPt == unit.healthPt);
            if (position == null)
                res = res && (unit.position == null);
            else
                res = res && (position.equals(unit.position));
            return res;
        }
    }
}

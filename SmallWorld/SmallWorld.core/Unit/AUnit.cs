﻿using System;

namespace SmallWorld.Core
{
    /// <summary>
    /// The AUnit class is an asbtract tempplate for game Units.
    /// </summary>
    [Serializable]
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
        /// </summary>
        /// <param name="defenderPos"></param>
        public void attack(AUnit defender, bool respond)
        {
            /*
            This method should update the life and eventually kill state of BOTH INVOLVED UNITS.
            */
            defender.loseHP(attackPt - defender.defencePt);
            if(respond)
            {
                // The defender will not fight back. //
                loseHP(defender.attackPt - defencePt);
            }
        }

        /// <summary>
        /// This method updates the current unit's health points, lowering them by the specified amount.
        /// If the current unit loses more health points than it has, its health points are set to 0.
        /// </summary>
        /// <param name="amount"></param>
        public void loseHP(int amount)
        {
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
    }
}

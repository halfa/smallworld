using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    [Serializable]
    public class GameState
    {
        public GameState()
        {
            turnCounter = 0;
            positionsUnits = new Dictionary<Position, List<AUnit>>();
            activePlayerIndex = 0;
            players = new List<Player>();
            selectedUnit = null;
        }

        /// <summary>
        /// Memberwise constructor for the GameState class.
        /// </summary>
        /// <param name="s"></param>
        public GameState(GameState s)
        {
            turnCounter = s.turnCounter;
            activePlayerIndex = s.activePlayerIndex;

            players = new List<Player>();
            foreach (Player p in s.players)
                players.Add(new Player(p));

            positionsUnits = GameState.concatPositionsUnits(players);

            if (s.selectedUnit != null)
            {
                UnitFactory factory = new UnitFactory();
                selectedUnit = factory.copyUnit(s.selectedUnit);
            }
            else
                selectedUnit = null;
        }

        /// <summary>
        /// Concats the respective positionsUnits dictionaries of the specified players into one.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static Dictionary<Position, List<AUnit>> concatPositionsUnits(List<Player> l)
        {
            Dictionary<Position, List<AUnit>> dic = new Dictionary<Position, List<AUnit>>();

            foreach (Player p in l)
            {
                Dictionary<Position, List<AUnit>> playerDic = p.getPositionsUnits();
                foreach (Position pos in playerDic.Keys)
                {
                    if (dic.ContainsKey(pos))
                    {
                        foreach (AUnit unit in playerDic[pos])
                            dic[pos].Add(unit);
                    }
                    else
                    {
                        List<AUnit> list = new List<AUnit>();
                        foreach (AUnit unit in playerDic[pos])
                            list.Add(unit);
                        dic.Add(pos, list);
                    }
                }
            }

            return dic;
        }

        public int turnCounter { get; set; }

        public Dictionary<Position, List<AUnit>> positionsUnits { get; set; }

        public int activePlayerIndex { get; set; }

        public List<Player> players { get; set; }

        public AUnit selectedUnit { get; set; }
    }
}
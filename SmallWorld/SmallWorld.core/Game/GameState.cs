using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the serializable game states.
    /// </summary>
    [Serializable]
    public class GameState
    {
        /// <summary>
        /// Constructor for the GameState class.
        /// </summary>
        public GameState()
        {
            turnCounter = 0;
            positionsUnits = new SerializableDictionary<Position, List<AUnit>>();
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
            /*
            if (s.selectedUnit != null)
            {
                UnitFactory factory = new UnitFactory();
                selectedUnit = factory.copyUnit(s.selectedUnit);
            }
            else*/
                selectedUnit = null;
        }

        /// <summary>
        /// Concats the respective positionsUnits dictionaries of the specified players into one.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static SerializableDictionary<Position, List<AUnit>> concatPositionsUnits(List<Player> l)
        {
            SerializableDictionary<Position, List<AUnit>> dic = new SerializableDictionary<Position, List<AUnit>>();

            foreach (Player p in l)
            {
                SerializableDictionary<Position, List<AUnit>> playerDic = p.getPositionsUnits();
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

        /// <summary>
        /// Read and write access to the current gameState's turnCounter field.
        /// </summary>
        public int turnCounter { get; set; }

        /// <summary>
        /// Read and write access to the current gameState's positionsUnits field.
        /// </summary>
        public SerializableDictionary<Position, List<AUnit>> positionsUnits { get; set; }

        /// <summary>
        /// Read and write access to the current gameState's activePlayerIndex field.
        /// </summary>
        public int activePlayerIndex { get; set; }

        /// <summary>
        /// Read and write access to the current gameState's players field.
        /// </summary>
        public List<Player> players { get; set; }

        /// <summary>
        /// Read and write access to the current gameState's selectedUnit field.
        /// </summary>
        public AUnit selectedUnit { get; set; }
    }
}
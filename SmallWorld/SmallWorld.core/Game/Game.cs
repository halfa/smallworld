using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for a game of SmallWorld.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Constructor for the Game class, according to the specified settings.
        /// This constructor should not be called upon, instead, use the GameBuilder class to obtain your Game instance.
        /// </summary>
        /// <param name="settings"></param>
        public Game(GameSettings settings)
        {
            gameSettings = settings;
        }

        /// <summary>
        /// Constructor for the Game class using the specified gameData to recreate the game.
        /// </summary>
        /// <param name="mapData"></param>
        public Game(GameData data)
        {
            currentState = data.currentState;
            gameSettings = data.gameSettings;
            map = new Map(data.mapData);
            previousGameStates = data.previousGameStates;
        }

        /// <summary>
        /// Read and write access to the current game's gameSettings field.
        /// </summary>
        public GameSettings gameSettings { get; set; }

        /// <summary>
        /// Read and write access to the current game's currentState field.
        /// </summary>
        public GameState currentState { get; set; }

        /// <summary>
        /// Read and write access to the current game's previousGameStates field.
        /// </summary>
        public Stack<GameState> previousGameStates { get; set; }

        /// <summary>
        /// Read and write access to the current game's map field.
        /// </summary>
        public Map map { get; set; }

        /// <summary>
        /// Determines the number of points the specified players would recieve regarding the current state of the game.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int countPoints(Player player)
        {
            return player.countPoints(map);
        }

        /// <summary>
        /// Terminates the current game turn.
        /// </summary>
        public void endGameTurn()
        {
            foreach (Player p in currentState.players)
                p.points += p.countPoints(map);
            if (isGameOver())
                // DO SOMETHING
                
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines the currently active player.
        /// </summary>
        /// <returns></returns>
        public Player getActivePlayer()
        {
            Player p = currentState.players[currentState.activePlayerIndex];
            if (p == null)
                throw new Exception("Invalid player index.");
            else
                return p;
        }

        /// <summary>
        /// Undoes the last action if possible, ie if actions have been stored.
        /// </summary>
        public void undo()
        {
            // Seems too easy to work fine :D! //
            if (previousGameStates.Count == 0)
                return;
            currentState = previousGameStates.Pop();
        }

        /// <summary>
        /// Determines the winner of the game if there is one.
        /// If a draw is stated, returns null.
        /// Called upon in case of a game end.
        /// *NOTE* This method won't work in case of a game involving any other number of players than 2.
        /// </summary>
        /// <returns></returns>
        public Player winner()
        {
            if (currentState.players.Exists(new Predicate<Player>(Player.isAlive)))
                // Not the best way to do it, but we have to check what the default value for type Player is,
                // because that's what is returned when no match is found.
                return currentState.players.Find(new Predicate<Player>(Player.isAlive));
            else
                return null;
        }

        /// <summary>
        /// Determines if the game is over, regarding the current game state.
        /// A Game is said to be over if the maximum nomber of turn has been reached, or if a player is dead.
        /// *NOTE* This method won't work in case of a game involving any other number of players than 2.
        /// </summary>
        /// <returns></returns>
        public bool isGameOver()
        {
            if (currentState.turnCounter == gameSettings.turnLimit)
                return true;
            return currentState.players.Exists(new Predicate<Player>(Player.isDead));
        }

        /// <summary>
        /// Creates the serializable data object representing the current game.
        /// </summary>
        /// <returns></returns>
        public GameData toData()
        {
            GameData data = new GameData();

            data.currentState = currentState;
            data.gameSettings = gameSettings;
            data.mapData = map.toData();
            data.previousGameStates = previousGameStates;

            return data;
        }

        /// <summary>
        /// Stacks the current game state onto the previous game states stack.
        /// The stored data is a memberwise copy of the current state data.
        /// </summary>
        public void stack()
        {
            GameState toStack = new GameState(currentState);
            previousGameStates.Push(toStack);
        }

        /// <summary>
        /// Determines in which order the findPath algorithm should explore adjacent tiles,
        /// in order to optimise the computed path if it exists.
        /// The path won't cross any tile on wich an enemy unit is located.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="to"></param>
        /// <param name="currentCost"></param>
        /// <param name="currentPath"></param>
        /// <returns></returns>
        private List<Position> heuristic(Position current, Position to, double currentCost, List<Position> currentPath)
        {
            List<Position> res = new List<Position>();

            double dx = to.x - current.x;
            double dy = to.y - current.y;

            Position up = new Position(current.x, current.y - 1);
            Position right = new Position(current.x + 1, current.y);
            Position down = new Position(current.x, current.y + 1);
            Position left = new Position(current.x - 1, current.y);

            if(dx > 0)
            {
                if(dy > 0)
                {
                    //3
                    if (dx >= dy)
                    {
                        // should go right first
                        res.Add(right);
                        res.Add(up);
                    }
                    else
                    {
                        // should go up first
                        res.Add(up);
                        res.Add(right);
                    }
                    res.Add(down);
                    res.Add(left);
                }
                if(dy < 0)
                {
                    //5
                    if (dx >= -dy)
                    {
                        // should go right first
                        res.Add(right);
                        res.Add(down);
                    }
                    else
                    {
                        // should down up first
                        res.Add(down);
                        res.Add(right);
                    }
                    res.Add(up);
                    res.Add(left);
                }
                else // dy == 0
                {
                    //4
                    res.Add(right);
                    res.Add(up);
                    res.Add(down);
                    res.Add(left);
                }
            }
            if(dx < 0)
            {
                if (dy > 0)
                {
                    //1
                    if (-dx >= dy)
                    {
                        // should go left first
                        res.Add(left);
                        res.Add(up);
                    }
                    else
                    {
                        // should go up first
                        res.Add(up);
                        res.Add(left);
                    }
                    res.Add(down);
                    res.Add(right);
                }
                if (dy < 0)
                {
                    //7
                    if (-dx >= -dy)
                    {
                        // should go left first
                        res.Add(left);
                        res.Add(down);
                    }
                    else
                    {
                        // should go down first
                        res.Add(down);
                        res.Add(left);
                    }
                    res.Add(up);
                    res.Add(right);
                }
                else // dy == 0
                {
                    //8
                    res.Add(left);
                    res.Add(up);
                    res.Add(down);
                    res.Add(right);
                }
            }
            else // dx == 0
            {
                if (dy > 0)
                {
                    //2
                    res.Add(up);
                    res.Add(left);
                    res.Add(right);
                    res.Add(down);
                }
                if (dy < 0)
                {
                    //6
                    res.Add(down);
                    res.Add(left);
                    res.Add(right);
                    res.Add(up);
                }
                else // dy == 0
                {
                    // current == to
                    // IMPOSSIBLE
                }
            }

            // Now clear from the advised positions the invalid ones. //
            // Not in bounds or not walkable. //
            foreach (Position p in res)
            {
                if (!map.inBound(p) || !currentState.selectedUnit.canCrossTile(map.getTileAtPos(p)))
                    res.Remove(p);
            }
            // Already crossed earlier. //
            foreach(Position p in res)
            {
                if (currentPath.Contains(p))
                    res.Remove(p);
            }
            // Enemy unit at pos. //
            foreach(Position p in res)
            {
                if (enemyUnitAtPos(p))
                    res.Remove(p);
            }
            // Not enough action points. //
            foreach (Position p in res) {
                double newCost = currentCost + currentState.selectedUnit.getMoveCost(map.getTileAtPos(p));
                if (newCost > currentState.selectedUnit.actionPool)
                    res.Remove(p);
            }
            return res;
        }


        /// <summary>
        /// Determines if there is at least one enemy unit (for the current player) at the specified position.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool enemyUnitAtPos(Position p)
        {
            if (map.inBound(p))
                if (currentState.positionsUnits.ContainsKey(p))
                    return !currentState.players[currentState.activePlayerIndex].units.Contains(currentState.positionsUnits[p][0]);

            return false;
        }

        /// <summary>
        /// Determines if the currently selected unit is in range of attack from the from position to the target position.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool inAttackRange(Position from, Position target)
        {
            int dx = Math.Abs(target.x - from.x);
            int dy = Math.Abs(target.y - from.y);
            int sum = dx + dy;
            int range = currentState.selectedUnit.getAttackRange(map.getTileAtPos(from));
            if (range < sum)
                return false;
            if(sum == 1)
                return true;
            if (sum == 2)
                return (dx == 0 || dy == 0);
            return false;
        }

        /// <summary>
        /// Computes a possible path from the specified tile to the specified tile, for the currently selected unit.
        /// If no valid path has been found, returns null.
        /// If the command is a move command, the path is leading to the specified potiion.
        /// If the command is an attack command, the path is leading to a tile in range of attack for the currently selected unit,
        /// with the unit having enough action points to perform the attack after moving in range.
        /// </summary>
        /// <param name="current">The current position. If it equals the target position, a path has been found.</param>
        /// <param name="to">The target position.</param>
        /// <param name="currentCost">The current cost of the path thus far.</param>
        /// <param name="currentPath">The current path created thus far.</param>
        /// <returns></returns>
        private List<Position> findPath(Position current, Position to, double currentCost, List<Position> currentPath, bool attack)
        {
            if(attack)
            {
                if (inAttackRange(current, to))
                    if(currentCost + currentState.selectedUnit.getMoveCost(map.getTileAtPos(current)) <= currentState.selectedUnit.actionPool)
                        return currentPath;
                return null;
            }
            else
            {
                if (current.equals(to))
                    return currentPath;
            }
            
            /* // NOT NEEDED BECAUSE IF A POSITION IS BEIING TESTED HERE? IT MEANS THAT THE HEURISTIC METHOD HAS BEEN CALLED, AND IT WOULD HAVE REMOVE THIS INVALID CHOICE.
            if (currentCost > currentState.selectedUnit.actionPool)
                return null;
            */
            List<Position> nextPos = heuristic(current, to, currentCost, currentPath);

            foreach(Position p in nextPos)
            {
                    double newCost = currentCost + currentState.selectedUnit.getMoveCost(map.getTileAtPos(p));
                    List<Position> newPath = new List<Position>();
                    foreach (Position pp in currentPath)
                        newPath.Add(pp);
                    newPath.Add(p);
                    List<Position> path = findPath(p, to, newCost, newPath, attack);
                    if (path != null)
                        return path;
            }
            return null;
        }

        /// <summary>
        /// Determines the cost of the specified path for the currently selected unit.
        /// The path is known to be valid, ie the positions are valid and the total cost if inferior or equal to the currently selected action pool.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private double computePathCost(List<Position> path)
        {
            double res = 0;
            foreach (Position p in path)
                res += currentState.selectedUnit.getMoveCost(map.getTileAtPos(p));
            return res;
        }

        /// <summary>
        /// Determines a possible path for the currently selected unit to the specified position.
        /// If a path exists, returns it as a list of positions.
        /// If no path was found, returns null.
        /// This method shall not be used to attack a unit at the specified position,
        /// for a position on which there is an enemy unit is considered invalid for the path.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public List<Position> isSelectedUnitMovableTo(Position position, bool attack)
        {
            if(currentState.players[currentState.activePlayerIndex].units.Contains(currentState.selectedUnit))
                return findPath(currentState.selectedUnit.position, position, 0, new List<Position>(), attack);
            return null;
        }

        /// <summary>
        /// Sets the selectedUnit field of the current game's currentState field to the first available unit at the specified position.
        /// If no unit is on the specified position, the selectedUnit field is set to null.
        /// A player can select an enemy unit, but he won't be able to give it orders.
        /// </summary>
        /// <param name="position"></param>
        public void selectUnitAt(Position position)
        {
            if (!currentState.positionsUnits.ContainsKey(position))
                currentState.selectedUnit = null;
            else
            {
                // Not sure if needed, we could update the dictionary when last unit leaves a position,
                // so that the key would not be there if no unit is in the list.
                if (currentState.positionsUnits[position].Count == 0)
                    currentState.selectedUnit = null;
                else
                    currentState.selectedUnit = currentState.positionsUnits[position][0];
            }
        }

        /// <summary>
        /// Currently moves the currently selected unit to the specified position if possible.
        /// DOENS'T HANDLE THE ATTACK CASE, and probably should not in any way.
        /// </summary>
        /// <param name="position"></param>
        public void moveSelectedUnitTo(Position position)
        {
            bool attack = enemyUnitAtPos(position);
            List<Position> path = isSelectedUnitMovableTo(position, attack);
            if (path == null)
                return;

            stack();
            Position to = path[path.Count - 1];
            AUnit selected = currentState.selectedUnit;
            Dictionary<Position, List<AUnit>> dic = currentState.positionsUnits;
            double cost = computePathCost(path);
            bool moveAfterAttack = !attack;

            // Now handles the attack if it was an attack comand.
            // If we are attacking, and we got a path, then it means we have enough action points to perform the attack, ie
            // if we kill the last unit, we move to the position if we are not range, if we don't kill the unit,
            // we still lose the action points for attacking only.
            if (attack)
            {
                bool respond = selected.getAttackRange(map.getTileAtPos(to)) == 1;
                AUnit defender = dic[position][0];
                selected.attack(defender, respond);
                
                if (defender.isDead())
                {
                    // Enemy unit died in battle, now we update the dictionary accordingly. //
                    int index = (currentState.activePlayerIndex + 1) % gameSettings.nbPlayers;
                    currentState.players[index].removeUnit(defender);
                    dic[position].Remove(defender);
                    if (dic[position].Count == 0)
                        dic.Remove(position);
                }
                if (selected.isDead())
                {
                    // Attacker died in battle.
                    currentState.players[currentState.activePlayerIndex].removeUnit(selected);
                    dic[selected.position].Remove(selected);
                    selected = null;
                }
                else
                {
                    cost += selected.getMoveCost(map.getTileAtPos(position));
                    // Because there was no other unit on that position than the enemy player's units. So if it's empty, then it's because the last of the units died.
                    if (defender.isDead() && !dic.ContainsKey(position))
                    {
                        // No other defender.
                        if (selected.getAttackRange(map.getTileAtPos(to)) != 2)
                        {
                            // We weren't attacking from range, so we move if we can. //
                            if (selected.canCrossTile(map.getTileAtPos(position)))
                            {
                                to = position;
                                moveAfterAttack = true;
                            }
                        }
                    }
                }
            }
            if(moveAfterAttack)
            {
                // Update the attacker position.
                // Updates the positionsUnits dictionary by removing the selected unit from the values associated with its position.
                // If it's the last unit on the said position, removes the key from the dictionary.
                dic[selected.position].Remove(selected);
                if (dic[selected.position].Count == 0)
                    dic.Remove(selected.position);

                // Updates the currently selected unit's fields.
                selected.position = to;
                selected.actionPool -= cost;

                // Updates the positionsUnits dictionary with the new values for the currently selected unit.
                if (!dic.ContainsKey(selected.position))
                    dic.Add(selected.position, new List<AUnit>() { selected });
                else
                    dic[selected.position].Add(selected);
            }
        }

        /// <summary>
        /// Terminates the current player's turn.
        /// If it was the last player to play during this game turn, call upon the endGameTurn method.
        /// </summary>
        /// <param name="player"></param>
        public void endPlayerTurn(Player player)
        {
            previousGameStates.Clear();
            currentState.selectedUnit = null;
            currentState.activePlayerIndex = (currentState.activePlayerIndex + 1) % (gameSettings.nbPlayers);
            if (currentState.activePlayerIndex == 0)
                endGameTurn();
        }
    }
}

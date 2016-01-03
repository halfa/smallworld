using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for a game of SmallWorld.
    /// </summary>
    public class Game
    {
        /* Constructors, getters and setters */

        /// <summary>
        /// Read and write access to the current game's currentState field.
        /// </summary>
        public GameState currentState { get; set; }

        /// <summary>
        /// Read and write access to the current game's gameSettings field.
        /// </summary>
        public GameSettings gameSettings { get; set; }

        /// <summary>
        /// Read and write access to the current game's map field.
        /// </summary>
        public Map map { get; set; }

        /// <summary>
        /// Read and write access to the current game's previousGameStates field.
        /// </summary>
        public Stack<GameState> previousGameStates { get; set; }

        /// <summary>
        /// Read and write access. If true, means that the game is not over. If false, the game is over and nothing else can be done.
        /// </summary>
        public bool running { get; set; }

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
            // We push all the states from the list onto the stack. //
            previousGameStates = new Stack<GameState>();
            // Reverting the order from the list to match the stack order. //
            data.previousGameStates.Reverse();
            foreach (GameState gs in data.previousGameStates)
                previousGameStates.Push(gs);

            running = data.running;
        }

        /* Points and end turns. */

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
        /// Terminates the current game.
        /// Now the winner method may be called.
        /// </summary>
        public void endGame()
        {
            running = false;
        }

        /// <summary>
        /// Terminates the current game turn.
        /// </summary>
        private void endGameTurn()
        {
            foreach (Player p in currentState.players)
            {
                p.points += p.countPoints(map);
                foreach(AUnit unit in p.units)
                    unit.restoreActionPool();
            }
            currentState.turnCounter++;
            if (isGameOverTurnLimit())
                endGame();
        }

        /// <summary>
        /// Terminates the current player's turn.
        /// If it was the last player to play during this game turn, calls upon the endGameTurn method.
        /// </summary>
        /// <param name="player"></param>
        public void endPlayerTurn()
        {
            // If the game is over, doesn't allow the next turn command. //
            if (!running)
                return;
            previousGameStates.Clear();
            currentState.selectedUnit = null;
            if (isGameOverSupremacy())
            {
                endGame();
            }
            else
            {
                currentState.activePlayerIndex = (currentState.activePlayerIndex + 1) % (gameSettings.nbPlayers);
                if (currentState.activePlayerIndex == 0)
                    endGameTurn();
            }
        }

        /// <summary>
        /// Determines if the game is over because a player has died, regarding the current game state.
        /// *NOTE* This method won't work in case of a game involving any other number of players than 2.
        /// </summary>
        /// <returns></returns>
        public bool isGameOverSupremacy()
        {
            return currentState.players.Exists(new Predicate<Player>(Player.isDead));
        }

        /// <summary>
        /// Determines if the game is over due to turn limit.
        /// </summary>
        /// <returns></returns>
        public bool isGameOverTurnLimit()
        {
            return currentState.turnCounter >= gameSettings.turnLimit;
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
            if (running)
                throw new Exception("Invalid call to the winner method: game still running.");
            if (currentState.turnCounter == gameSettings.turnLimit)
            {
                // Victory or draw by points. //
                // If the game ended with a player dead at the same time. //
                if (currentState.players.Exists(new Predicate<Player>(Player.isDead)))
                    return currentState.players.Find(new Predicate<Player>(Player.isAlive));
                int p1Score = currentState.players[0].points;
                int p2Score = currentState.players[1].points;
                if (p1Score == p2Score)
                    return null;
                if (p1Score > p2Score)
                    return currentState.players[0];
                return currentState.players[1];
            }
            if (currentState.players.Exists(new Predicate<Player>(Player.isAlive)))
                // Not the best way to do it, but we have to check what the default value for type Player is,
                // because that's what is returned when no match is found.
                return currentState.players.Find(new Predicate<Player>(Player.isAlive));
            else
                return null;
        }

        /* Game state management. */

        /// <summary>
        /// Stacks the current game state onto the previous game states stack.
        /// The stored data is a memberwise copy of the current state data.
        /// We do not stack a copy of the selected unit, but null instead, for data consistency between players' units, and selectedUnit.
        /// Thus, the unit will have to be re-selected if a previous state is reloaded.
        /// </summary>
        public void stack()
        {
            GameState toStack = new GameState(currentState);
            previousGameStates.Push(toStack);
        }

        /// <summary>
        /// Undoes the last action if possible, ie if actions have been stored.
        /// </summary>
        public void undo()
        {
            // If the game is over, it means that the previous player accepted the loss, so we don't allow the undo command. //
            if (!running)
                return;
            if (previousGameStates.Count == 0)
                return;
            currentState = previousGameStates.Pop();
        }

        /* Selecting and moving units. */

        /// <summary>
        /// Determines the cost of the specified path for the currently selected unit.
        /// The path is known to be valid, ie the positions are valid and the total cost is inferior or equal to the currently selected unit's action pool.
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
        /// Determines if there is at least one enemy unit (for the current player) at the specified position.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool enemyUnitAtPos(Position p)
        {
            if (map.inBound(p))
            {
                List<AUnit> units = getUnitsAt(p);
                if (units.Count != 0)
                    return !currentState.players[currentState.activePlayerIndex].hasUnit(units[0]);
            }
            return false;
        }

        /// <summary>
        /// Determines the best defender at the specified position.
        /// This method should only be called after verifying that the specified position is in bounds,
        /// and contains enemy units.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private AUnit findBestDefenderAt(Position position)
        {
            List<AUnit> defenders = getUnitsAt(position);
            AUnit res = defenders[0];
            for (int i = 1; i < defenders.Count; i++)
                if (res.defencePt < defenders[i].defencePt)
                    res = defenders[i];
            return res;
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
            if (attack)
            {
                if (inAttackRange(current, to))
                    if (currentCost + currentState.selectedUnit.getMoveCost(map.getTileAtPos(current)) <= currentState.selectedUnit.actionPool)
                        return currentPath;
            }
            else
            {
                if (current.equals(to))
                    return currentPath;
            }

            List<Position> nextPos = heuristic(current, to, currentCost, currentPath);

            foreach (Position p in nextPos)
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
        /// Determines the currently active player.
        /// </summary>
        /// <returns></returns>
        public Player getActivePlayer()
        {
            Player p = currentState.players[currentState.activePlayerIndex];
            if (p == null)
                throw new Exception("No player at specified index.");
            else
                return p;
        }

        /// <summary>
        /// Determines in which order the findPath algorithm should explore adjacent tiles,
        /// in order to optimise the computed path if it exists.
        /// The path won't cross any tile on wich an enemy unit is located.
        /// This heuristic is suited for the game rules, ie regarding the number of possible moves, there are very few
        /// to no case in which the computed path would not be one of the shortest paths possible.
        /// </summary>
        /// <param name="current">Current player's unit position</param>
        /// <param name="to">Unit destination position</param>
        /// <param name="currentCost"></param>
        /// <param name="currentPath"></param>
        /// <returns></returns>
        private List<Position> heuristic(Position current, Position to, double currentCost, List<Position> currentPath)
        {
            List<Position> res = new List<Position>();

            int dx = to.x - current.x;
            int dy = to.y - current.y;

            Position up = new Position(current.x, current.y - 1);
            Position right = new Position(current.x + 1, current.y);
            Position down = new Position(current.x, current.y + 1);
            Position left = new Position(current.x - 1, current.y);

            // Here is a drawing of the possible GENERAL directions to evaluate. //
            // x is the current position. //
            /*
                1   2   3
                8   x   4
                7   6   5   
            */

            if (dx > 0)
            {
                if (dy > 0)
                {
                    //5
                    if (dx >= dy)
                    {
                        // should go right first
                        res.Add(right);
                        res.Add(down);
                    }
                    else
                    {
                        // should go down first
                        res.Add(down);
                        res.Add(right);
                    }
                    res.Add(up);
                    res.Add(left);
                }
                if (dy < 0)
                {
                    //3
                    if (dx >= -dy)
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
                else // dy == 0
                {
                    //4
                    res.Add(right);
                    res.Add(up);
                    res.Add(down);
                    res.Add(left);
                }
            }
            if (dx < 0)
            {
                if (dy > 0)
                {
                    //7
                    if (-dx >= dy)
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
                if (dy < 0)
                {
                    //1
                    if (-dx >= -dy)
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
                    //6
                    res.Add(down);
                    res.Add(left);
                    res.Add(right);
                    res.Add(up);
                }
                if (dy < 0)
                {
                    //2
                    res.Add(up);
                    res.Add(left);
                    res.Add(right);
                    res.Add(down);
                }
                else // dy == 0
                {
                    // current == to
                    // IMPOSSIBLE
                }
            }

            // Now clear from the advised positions the invalid ones. //

            List<Position> removable = new List<Position>();
            foreach (Position p in res)
            {
                // Not in bounds or not walkable. // Already crossed earlier. // Enemy unit at pos. //
                if (!map.inBound(p) || !currentState.selectedUnit.canCrossTile(map.getTileAtPos(p))
                    || currentPath.Contains(p) || enemyUnitAtPos(p))
                    removable.Add(p);
                else
                {
                    // Not enough action points. //
                    double newCost = currentCost + currentState.selectedUnit.getMoveCost(map.getTileAtPos(p));
                    if (newCost > currentState.selectedUnit.actionPool)
                        removable.Add(p);
                }
            }
            foreach (Position p in removable)
                res.Remove(p);
            return res;
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
            if (sum == 1)
                return true;
            if (sum == 2)
                return (dx == 0 || dy == 0);
            return false;
        }

        /// <summary>
        /// If the selected unit is a valid target for a move / attack command (ie it belongs to the active player, and the target position is valid),
        /// determines a possible path for the currently selected unit to the specified position.
        /// If a path exists, returns it as a list of positions.
        /// If no path was found, returns null.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public List<Position> isSelectedUnitMovableTo(Position position, bool attack)
        {
            if (!map.inBound(position) || currentState.selectedUnit == null)
                return null;
            if (currentState.players[currentState.activePlayerIndex].hasUnit(currentState.selectedUnit))
                return findPath(currentState.selectedUnit.position, position, 0, new List<Position>(), attack);
            return null;
        }

        /// <summary>
        /// Moves the currently selected unit to the specified position if possible.
        /// Handles the update of all the data regarding units positioning.
        /// </summary>
        /// <param name="position"></param>
        public void moveSelectedUnitTo(Position position)
        {
            // If the game is over, doesn't allow the move command. //
            if (!running)
                return;
            bool attack = enemyUnitAtPos(position);
            List<Position> path = isSelectedUnitMovableTo(position, attack);
            // If no path has been found or the selected target tile was the original tile of the moving unit. //
            if (path == null || path.Count == 0)
                return;

            stack();
            Position to = path[path.Count - 1];
            AUnit selected = currentState.selectedUnit;

            double cost = computePathCost(path);

            // Now handles the attack if it was an attack comand.
            // If we are attacking, and we got a path, then it means we have enough action points to perform the attack, ie
            // if we kill the last unit, we move to the position if we are not range, if we don't kill the unit,
            // we still lose the action points for attacking only.
            if (attack)
            {
                AUnit defender = findBestDefenderAt(position);
                selected.attack(defender);

                if (defender.isDead())
                {
                    // Enemy unit died in battle, now we update the dictionary accordingly. //
                    int index = (currentState.activePlayerIndex + 1) % gameSettings.nbPlayers;
                    currentState.players[index].removeUnit(defender);
                }
                cost += selected.getMoveCost(map.getTileAtPos(position));
                List<AUnit> defenders = getUnitsAt(position);
                if (defender.isDead() && defenders.Count == 0)
                {
                    if (selected.getAttackRange(map.getTileAtPos(to)) != 2)
                    {
                        // We weren't attacking from range, so we move if we can. //
                        if (selected.canCrossTile(map.getTileAtPos(position)))
                            to = position;
                    }
                }
            }
            // Updates the currently selected unit's fields.
            selected.position = to;
            selected.actionPool -= cost;
        }

        /// <summary>
        /// Sets the selectedUnit field of the current game's currentState field to the first available unit at the specified position.
        /// If the specified position matches the currently selected unit's position, then updates the currently selected unit to be the
        /// next unit at the said tile. If it is the only unit, then the update will have no effect.
        /// If no unit is on the specified position, the selectedUnit field is set to null.
        /// A player can select an enemy unit, but he won't be able to give it orders.
        /// </summary>
        /// <param name="position"></param>
        public void selectUnitAt(Position position)
        {
            List<AUnit> units = getUnitsAt(position);
            if (units.Count == 0)
                currentState.selectedUnit = null;
            else
            {
                if (currentState.selectedUnit == null)
                    currentState.selectedUnit = units[0];
                else
                {
                    if (currentState.selectedUnit.position.Equals(position))
                    {
                        int curIndex = units.IndexOf(currentState.selectedUnit);
                        if (curIndex == -1)
                            throw new Exception("Invalid state of selected unit.");
                        curIndex = (curIndex + 1) % units.Count;
                        currentState.selectedUnit = units[curIndex];
                    }
                    else
                        currentState.selectedUnit = units[0];
                }
            }
        }

        /// <summary>
        /// Determines the units at the specified position.
        /// The returned list of units will only contain units of 1 player only, because of the game rules.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<AUnit> getUnitsAt(Position p)
        {
            List<AUnit> p1 = currentState.players[0].units.Where(r => (r.position.equals(p))).ToList();
            List<AUnit> p2 = currentState.players[1].units.Where(r => (r.position.equals(p))).ToList();
            return p1.Concat(p2).ToList();
        }

        /* Serialization. */

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
            // We pop all the states into the list. //
            while (previousGameStates.Count != 0)
                data.previousGameStates.Add(previousGameStates.Pop());

            return data;
        }

        /*  Move suggestions from the C++. */

        /// <summary>
        /// Determines a maximum of three intersting possible moves for the currently selected friendly unit.
        /// </summary>
        /// <returns></returns>
        public List<Position> suggestMove()
        {
            List<Position> res = new List<Position>();
            // If there is no selected unit, or the selected unit doesn't belong to the active player, does nothing.
            if (currentState.selectedUnit == null || !currentState.players[currentState.activePlayerIndex].hasUnit(currentState.selectedUnit))
                return res;

            int x = currentState.selectedUnit.position.x;
            int y = currentState.selectedUnit.position.y;

            // Adjacent positions as follow: //
            /*  
                .   .   9   .   .
                .   1   2   3   .
                12  8   0   4   10
                .   7   6   5   .
                .   .   11  .   .
            */

            List<Position> adjacentPositions = new List<Position>();
            adjacentPositions.Add(new Position(x, y));      // 0
            adjacentPositions.Add(new Position(x-1, y-1));  // 1
            adjacentPositions.Add(new Position(x, y-1));    // 2
            adjacentPositions.Add(new Position(x+1, y-1));  // 3
            adjacentPositions.Add(new Position(x+1, y));    // 4
            adjacentPositions.Add(new Position(x+1, y+1));  // 5
            adjacentPositions.Add(new Position(x, y+1));    // 6
            adjacentPositions.Add(new Position(x-1, y+1));  // 7
            adjacentPositions.Add(new Position(x-1, y));    // 8
            adjacentPositions.Add(new Position(x, y-2));    // 9
            adjacentPositions.Add(new Position(x+2, y));    // 10
            adjacentPositions.Add(new Position(x, y+2));    // 11
            adjacentPositions.Add(new Position(x-2, y));    // 12

            // Removing the impossible positions to reach. //
            List<Position> removable = new List<Position>();

            foreach(Position p in adjacentPositions)
                if (!map.inBound(p) || !currentState.selectedUnit.canCrossTile(map.getTileAtPos(p)))
                    removable.Add(p);

            foreach (Position p in removable)
                adjacentPositions.Remove(p);

            int[] points = new int[adjacentPositions.Count];
            for (int i = 0; i < adjacentPositions.Count; i++)
                points[i] = currentState.selectedUnit.countPoints(map.getTileAtPos(adjacentPositions[i]));

            Algo algo = new Algo();
            List<int> indexes = algo.suggestMove(points, adjacentPositions.Count);
            foreach (int n in indexes)
                res.Add(adjacentPositions[n]);

            return res;
        }
    }
}

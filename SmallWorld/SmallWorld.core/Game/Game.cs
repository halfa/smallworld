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
        /// Computes a possible path from the specified tile to the specified tile, for the currently selected unit.
        /// If no valid path has been found, returns null.
        /// </summary>
        /// <param name="current">The current position. If it equals the target position, a path has been found.</param>
        /// <param name="to">The target position.</param>
        /// <param name="currentCost">The current cost of the path thus far.</param>
        /// <param name="currentPath">The current path created thus far.</param>
        /// <returns></returns>
        private List<Position> findPath(Position current, Position to, double currentCost, List<Position> currentPath)
        {
            if (current.equals(to))
                return currentPath;
            if (currentCost > currentState.selectedUnit.actionPool)
                return null;

            Position up = new Position(current.x, current.y - 1);
            Position right = new Position(current.x + 1, current.y);
            Position down = new Position(current.x, current.y + 1);
            Position left = new Position(current.x - 1, current.y);
            List<Position> nextPos = new List<Position>() { up, right, down, left };

            foreach(Position p in nextPos)
            {
                if (map.inBound(p) && currentState.selectedUnit.canCrossTile(map.getTileAtPos(p)))
                {
                    double newCost = currentCost + currentState.selectedUnit.getMoveCost(map.getTileAtPos(p));
                    List<Position> newPath = new List<Position>();
                    foreach (Position pp in currentPath)
                        newPath.Add(pp);
                    newPath.Add(p);
                    List<Position> path = findPath(p, to, newCost, newPath);
                    if (path != null)
                        return path;
                }
            }
            return null;
        }

        /// <summary>
        /// Determines the cost of the specified path for the currently selected unit.
        /// The path is know to be valid, ie the positions are valid and the total cost if inferior or equal to the currently selected action pool.
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
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public List<Position> isSelectedUnitMovableTo(Position position)
        {
            if(currentState.players[currentState.activePlayerIndex].units.Contains(currentState.selectedUnit))
                return findPath(currentState.selectedUnit.position, position, 0, new List<Position>());
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

        public void moveSelectedUnitTo(Position position)
        {
            List<Position> path = isSelectedUnitMovableTo(position);
            if (path == null)
                return;
            stack();
            double cost = computePathCost(path);

            // Updates the positionsUnits dictionary by removing the selected unit from the values associated with its position.
            // If it's the last unit on the said position, removes the key from the dictionary.
            currentState.positionsUnits[currentState.selectedUnit.position].Remove(currentState.selectedUnit);
            if (currentState.positionsUnits[currentState.selectedUnit.position].Count == 0)
                currentState.positionsUnits.Remove(currentState.selectedUnit.position);
            else
                currentState.positionsUnits[currentState.selectedUnit.position].Remove(currentState.selectedUnit);

            // Updates the currently selected unit's fields.
            currentState.selectedUnit.position = position;
            currentState.selectedUnit.actionPool -= cost;

            // Updates the positionsUnits dictionary with the new values for the currently selected unit.
            if(!currentState.positionsUnits.ContainsKey(currentState.selectedUnit.position))
            {
                List<AUnit> list = new List<AUnit>() { currentState.selectedUnit };
                currentState.positionsUnits.Add(currentState.selectedUnit.position, list);
            }
            else
            {
                currentState.positionsUnits[currentState.selectedUnit.position].Add(currentState.selectedUnit);
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

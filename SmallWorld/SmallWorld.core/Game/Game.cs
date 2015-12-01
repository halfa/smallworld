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
            orderedPlayers = new List<Player>();
            foreach (PlayerData p in data.orderedPlayersData)
                orderedPlayers.Add(new Player(p));
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
        /// Read and write access to the current game's orderedPlayers field.
        /// </summary>
        public List<Player> orderedPlayers { get; set; }

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
            foreach (Player p in orderedPlayers)
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
            Player p = orderedPlayers[currentState.activePlayerIndex];
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
            if (orderedPlayers.Exists(new Predicate<Player>(Player.isAlive)))
                // Not the best way to do it, but we have to check what the default value for type Player is,
                // because that's what is returned when no match is found.
                return orderedPlayers.Find(new Predicate<Player>(Player.isAlive));
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
            return orderedPlayers.Exists(new Predicate<Player>(Player.isDead));
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
            foreach (Player p in orderedPlayers)
                data.orderedPlayersData.Add(p.toData());
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

        public bool isSelectedUnitMovableTo(Position position)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Terminates the current player's turn.
        /// If it was the last player to play during this game turn, call upont the endGameTurn method.
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

using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for game builders.
    /// Game builders are used to create a Game object, according to the specified GameSettings object.
    /// </summary>
    public class GameBuilder : IGameBuilder
    {
        /// <summary>
        /// Read and write access to the game settings used to build the game.
        /// </summary>
        public GameSettings gameSettings { get; set; }

        /// <summary>
        /// Constructor for the GameBuilder class.
        /// </summary>
        public GameBuilder(GameSettings settings)
        {
            gameSettings = settings;
        }

        /// <summary>
        /// Creates a game according to the settings, and returns it.
        /// If no settings are available, throws a new Exception.
        /// </summary>
        /// <returns></returns>
        public Game build()
        {
            if (gameSettings == null)
                throw new Exception("Invalid game settings.");
            else
            {
                Game game = new Game(gameSettings);

                game.running = true;

                // Setup the map. //
                MapType mapType = gameSettings.mapType;
                Map map = new Map(mapType);
                game.map = map;

                // Create the players. //
                List<Player> players = new List<Player>(gameSettings.nbPlayers);
                for(int i = 0; i < gameSettings.nbPlayers; i++)
                {
                    Player p = new Player(gameSettings.playersNames[i], gameSettings.playersRaces[i]);
                    players.Add(p);
                }

                // Randomize the players order. //
                Random rd = new Random();
                for(int i = 0; i < gameSettings.nbPlayers; i++)
                {
                    int r = rd.Next() % gameSettings.nbPlayers;
                    Player tmp = players[i];
                    players[i] = players[r];
                    players[r] = tmp;
                }

                // Add units to the players. //
                foreach (Player p in players)
                    for (int i = 0; i < gameSettings.unitLimit; i++)
                        p.addNewUnit();

                // Find the random default position for each player according to its race. //
                List<Position> rdmPos = new List<Position>(gameSettings.nbPlayers);

                Position posP1 = map.getRandomStartPos(players[0].race);
                rdmPos.Add(posP1);

                Position firstRandom = map.getRandomStartPos(players[1].race);
                while (firstRandom.equals(posP1))
                    firstRandom = map.getRandomStartPos(players[1].race);

                rdmPos.Add(firstRandom);

                // Tries to find another random position for the second player, that would be further from the one of the furst player. //
                Position posP2;
                for (int i = 0; i < 10; i++)
                {
                    posP2 = map.getRandomStartPos(players[1].race);
                    while(posP2.equals(posP1))
                        posP2 = map.getRandomStartPos(players[1].race);

                    int dxOld = Math.Abs(posP1.x - rdmPos[1].x);
                    int dyOld = Math.Abs(posP1.y - rdmPos[1].y);
                    int sumOld = dxOld + dyOld;

                    int dxNew = Math.Abs(posP1.x - posP2.x);
                    int dyNew = Math.Abs(posP1.y - posP2.y);
                    int sumNew = dxNew + dyNew;

                    if (sumNew > sumOld)
                        rdmPos[1] = new Position(posP2);
                }

                // Set the players' units' default position to the randomly generated one. //
                for (int i = 0; i < gameSettings.nbPlayers; i++)
                    foreach (AUnit unit in players[i].units)
                        unit.position = rdmPos[i];

                // Now the players are ready. //

                // Setup the game states stack. //
                Stack<GameState> stack = new Stack<GameState>();
                game.previousGameStates = stack;

                // Setup the current game state. //
                GameState startState = new GameState();

                startState.activePlayerIndex = 0;
                startState.players = players;
                startState.selectedUnit = null;
                startState.positionsUnits = GameState.concatPositionsUnits(players);
                startState.turnCounter = 0;

                game.currentState = startState;

                return game;
            }
        }
    }
}
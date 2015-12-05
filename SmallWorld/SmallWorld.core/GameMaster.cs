namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the main class of the application: the game of SmallWorld.
    /// </summary>
    public class GameMaster
    {
        /// <summary>
        /// Read and write access to the current smallWorld's game field.
        /// </summary>
        public Game game { get; set; }

        /// <summary>
        /// Read only access to the current smallWorld's saveManager field.
        /// </summary>
        public ISaveManager saveManager { get; set; }

        /// <summary>
        /// Read only access to the current smallWorld's loadManager field.
        /// </summary>
        public ILoadManager loadManager { get; set; }

        /// <summary>
        /// Sets the current smallWorld's game field to the loaded game specified by the filePath.
        /// </summary>
        /// <param name="filePath"></param>
        public void loadGame(string filePath)
        {
            if(loadManager.loadGame(filePath))
                game = loadManager.game;
        }

        /// <summary>
        /// Saves the current smallWorld's game to the specified filePath.
        /// </summary>
        /// <param name="filePath"></param>
        public void saveGame(string filePath)
        {
            saveManager.savable = game;
            saveManager.save(filePath);
        }

        /// <summary>
        /// Sets the current smallWorld's game field to be a new game according to the specified gameSettings.
        /// </summary>
        /// <param name="settings"></param>
        public void newGame(GameSettings settings)
        {
            GameBuilder builder = new GameBuilder(settings);
            game = builder.build();
        }

        /// <summary>
        /// Default constructor for the GameMaster class.
        /// </summary>
        public GameMaster() {
            saveManager = new SaveManager();
            loadManager = new LoadManager();
        }
    }
}

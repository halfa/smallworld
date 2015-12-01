using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SmallWorld.Core;

namespace SmallWorld.gui
{
    /// <summary>
    /// Interaction logic for the start window
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameMaster GM { get; protected set; }
        public GameSettings GS { get; protected set; }

        public MainWindow()
        {
            InitializeComponent();
            GM = new GameMaster();
            GS = new GameSettings();

            // default builder - this match the interface parameters
            GS.mapType = MapType.Demo;
            GS.nbPlayers = 2;
            GS.playersNames.Add("Player1");
            GS.playersNames.Add("Player2");
            GS.playersRaces.Add(Races.Elf);
            GS.playersRaces.Add(Races.Human);
        }

        private void player1_race_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void player2_race_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// Check check provided datas and launch the game
        /// </summary>
        private void start_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

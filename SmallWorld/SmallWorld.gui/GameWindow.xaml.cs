using SmallWorld.Core;
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
using System.Windows.Shapes;

namespace SmallWorld.gui
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Map map;
        public GameWindow(GameSettings settings)
        {
            InitializeComponent();
            GameWindowViewModel dataContext = new GameWindowViewModel(settings);
            map = dataContext.GM.game.map;
            DataContext = dataContext;
        }

        private void GameWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < map.width; i++)
            {
                Game_Display_Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(40, GridUnitType.Pixel) });
            }
            for (int i = 0; i < map.height; i++)
            {
                Game_Display_Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(40, GridUnitType.Pixel) });
            }
        }
    }
}

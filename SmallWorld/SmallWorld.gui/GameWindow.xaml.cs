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

        private static int IMGSIZE = 48;

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
                Game_Display_Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(IMGSIZE, GridUnitType.Pixel) });
            }
            for (int i = 0; i < map.height; i++)
            {
                Game_Display_Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(IMGSIZE, GridUnitType.Pixel) });
            }

            initializeTilesDisplay();
        }

        private void initializeTilesDisplay()
        {
            for(int i = 0; i < map.width; i++)
            {
                for(int j = 0; j < map.height; j++)
                {
                    Image img = getImageForTile(map.tiles[j * map.width + i].getType());
                    Grid.SetRow(img, j);
                    Grid.SetColumn(img, i);
                    Game_Display_Grid.Children.Add(img);
                }
            }
        }

        private Image getImageForTile(TileType t)
        {
            string requested = "";
            switch(t)
            {
                case TileType.Forest:
                    requested = "forest";
                    break;
                case TileType.Mountain:
                    requested = "mountain";
                    break;
                case TileType.Plain:
                    requested = "plain";
                    break;
                case TileType.Water:
                    requested = "water";
                    break;
                default:
                    requested = "water";
                    break;
            }
            Image img = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("images\\"+requested+".jpg", UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            img.Source = src;

            return img;
        }
    }
}

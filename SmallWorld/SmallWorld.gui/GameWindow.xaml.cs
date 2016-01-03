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
        private GameWindowViewModel GWVM;

        private static int IMGSIZE = 60;

        public GameWindow(GameSettings settings)
        {
            InitializeComponent();
            GWVM = new GameWindowViewModel(settings);
            DataContext = GWVM;
        }

        private void GameWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            Map map = GWVM.GM.game.map;
            for (int i = 0; i < map.width; i++)
            {
                Game_Display_Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(IMGSIZE, GridUnitType.Pixel) });
            }
            for (int i = 0; i < map.height; i++)
            {
                Game_Display_Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(IMGSIZE, GridUnitType.Pixel) });
            }

            initializeTilesDisplay();
            initializeUnitsDisplay();
        }

        private void initializeTilesDisplay()
        {
            Map map = GWVM.GM.game.map;
            for (int i = 0; i < map.width; i++)
            {
                for(int j = 0; j < map.height; j++)
                {
                    Image img = getImageForTile(map.tiles[j * map.width + i].getType());
                    Grid.SetRow(img, j);
                    Grid.SetColumn(img, i);
                    img.MouseLeftButtonDown += Tile_Left_Clicked;
                    Game_Display_Grid.Children.Add(img);
                }
            }
        }

        private void initializeUnitsDisplay()
        {
            GameState curState = GWVM.GM.game.currentState;
            foreach(Player p in curState.players)
            {
                foreach(AUnit unit in p.units)
                {
                    Image img = getImageForRace(p.race);
                    Grid.SetZIndex(img, 222);
                    Grid.SetRow(img, unit.position.y);
                    Grid.SetColumn(img, unit.position.x);
                    img.MouseLeftButtonDown += Tile_Left_Clicked;
                    Game_Display_Grid.Children.Add(img);
                }
            }
        }

        private Image getImageForRace(Races r)
        {
            string requested = "";
            switch(r)
            {
                case Races.Elf:
                    requested = "elf_unit.png";
                    break;
                case Races.Human:
                    requested = "human_unit.png";
                    break;
                case Races.Orc:
                    requested = "orc_unit.png";
                    break;
                default:
                    requested = "orc_unit.png";
                    break;
            }
            Image img = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("images\\" + requested, UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            img.Source = src;

            return img;
        }

        private void Tile_Left_Clicked(object sender, RoutedEventArgs e)
        {
            if(sender.GetType().Equals(typeof(Image)))
            {
                Image img = (Image)sender;

                int co = Grid.GetColumn(img);
                int ro = Grid.GetRow(img);

                GWVM.selectUnitAt(co, ro);

                Grid.SetColumn(SelectionRectangle, co);
                Grid.SetRow(SelectionRectangle, ro);
                if (GWVM.SelectedUnit == null)
                    GWVM.SelectedVisible = Visibility.Hidden;
                else
                    GWVM.SelectedVisible = Visibility.Visible;


                e.Handled = true;
            }
        }

        private Image getImageForTile(TileType t)
        {
            string requested = "";
            switch(t)
            {
                case TileType.Forest:
                    requested = "forest.jpg";
                    break;
                case TileType.Mountain:
                    requested = "mountain.jpg";
                    break;
                case TileType.Plain:
                    requested = "plain.jpg";
                    break;
                case TileType.Water:
                    requested = "water.jpg";
                    break;
                default:
                    requested = "water.jpg";
                    break;
            }
            Image img = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("images\\"+requested, UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            img.Source = src;

            return img;
        }

    }
}

using SmallWorld.Core;
using System.Windows;

namespace SmallWorld.gui
{
    /// <summary>
    /// Logique d'interaction pour VictoryWindow.xaml
    /// </summary>
    public partial class VictoryWindow : Window
    {
        public VictoryWindow(Player p)
        {
            InitializeComponent();
            DataContext = new VictoryWindowViewModel(p);
        }
    }
}

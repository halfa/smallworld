using SmallWorld.Core;
using System.Windows;

namespace SmallWorld.gui
{
    /// <summary>
    /// Logique d'interaction pour LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        private LoadWindowViewModel LWVM;
        public LoadWindow()
        {
            InitializeComponent();
            LWVM = new LoadWindowViewModel();
            DataContext = LWVM;
        }
    }
}

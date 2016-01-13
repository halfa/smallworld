using System.Windows;

namespace SmallWorld.gui
{
    /// <summary>
    /// Logique d'interaction pour HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
            DataContext = new HelpWindowViewModel();
        }
    }
}

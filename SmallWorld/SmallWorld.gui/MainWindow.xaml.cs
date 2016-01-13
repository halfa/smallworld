using System.Windows;

namespace SmallWorld.gui
{
    /// <summary>
    /// Interaction logic for the start window
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel MWVM;
        public MainWindow()
        {
            InitializeComponent();
            MWVM = new MainWindowViewModel();
            DataContext = MWVM;
        }

        private void start_Click_1(object sender, RoutedEventArgs e)
        {
            if (MWVM.StartClick.CanExecute(null))
            {
                MWVM.StartClick.Execute(null);
                Close();
            }
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            if(MWVM.LoadClick.CanExecute(null))
            {
                MWVM.LoadClick.Execute(null);
                if(MWVM.HasToClose)
                    Close();
            }
        }
    }
}

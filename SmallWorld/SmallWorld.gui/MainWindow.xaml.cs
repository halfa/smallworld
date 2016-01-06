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

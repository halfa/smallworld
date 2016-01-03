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
    /// Logique d'interaction pour SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        private SaveWindowViewModel SWVM;
        public SaveWindow(GameMaster gm)
        {
            InitializeComponent();
            SWVM = new SaveWindowViewModel(gm);
            DataContext = SWVM;
        }
    }
}

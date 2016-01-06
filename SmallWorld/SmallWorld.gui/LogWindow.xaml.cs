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
    /// Logique d'interaction pour LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public LogWindowViewModel LWVM;
        public LogWindow(LogWindowViewModel lwvm)
        {
            InitializeComponent();
            LWVM = lwvm;
            DataContext = LWVM;
        }

        private void textBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Scroll.ScrollToBottom();
        }
    }
}

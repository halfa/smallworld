using System.Windows;

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

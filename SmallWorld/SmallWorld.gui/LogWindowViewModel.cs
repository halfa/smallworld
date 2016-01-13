using System.ComponentModel;

namespace SmallWorld.gui
{
    public class LogWindowViewModel : INotifyPropertyChanged
    {
        private string log;
        public string Log { get { return log; } set { log = value; OnPropertyChanged("Log"); } }

        public LogWindowViewModel()
        {
            Log = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

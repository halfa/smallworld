using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.gui
{
    public class LogWindowViewModel : INotifyPropertyChanged
    {
        private string log;
        public string Log { get { return log; } set { log = value; OnPropertyChanged("Log"); } }

        public LogWindowViewModel()
        {
            Log = "No log.";
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

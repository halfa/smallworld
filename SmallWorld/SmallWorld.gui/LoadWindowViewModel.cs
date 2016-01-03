using SmallWorld.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmallWorld.gui
{
    class LoadWindowViewModel : INotifyPropertyChanged
    {

        private string filePath;
        public string FilePath { get { return filePath; } set { filePath = value; OnPropertyChanged("FilePath"); } }

        public LoadWindowViewModel()
        {
        }

        private ICommand loadClick;
        public ICommand LoadClick
        {
            get
            {
                if (loadClick == null)
                    loadClick = new RelayCommand(param => load_Click(), param => true);
                return loadClick;
            }
        }
        public void load_Click()
        {
            GameMaster GM = new GameMaster();
            GM.loadGame(FilePath);
            if (GM.game == null)
                return;
            GameWindow win = new GameWindow(GM);
            win.Show();
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

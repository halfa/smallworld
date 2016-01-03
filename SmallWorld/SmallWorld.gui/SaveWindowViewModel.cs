using SmallWorld.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace SmallWorld.gui
{
    public class SaveWindowViewModel : INotifyPropertyChanged
    {
        public GameMaster GM { get; protected set; }

        private string filePath;
        public string FilePath { get { return filePath; } set { filePath = value;  OnPropertyChanged("FilePath"); } }

        public SaveWindowViewModel(GameMaster gm)
        {
            GM = gm;
        }


        private ICommand saveClick;
        public ICommand SaveClick
        {
            get
            {
                if (saveClick == null)
                    saveClick = new RelayCommand(param => save_Click(), param => true);
                return saveClick;
            }
        }
        public void save_Click()
        {
            GM.saveGame(FilePath);
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
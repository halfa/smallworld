using SmallWorld.Core;
using System.ComponentModel;

namespace SmallWorld.gui
{
    class VictoryWindowViewModel : INotifyPropertyChanged
    {
        private Player player;

        private string message;
        public string Message { get { return message; } set { message = value;  OnPropertyChanged("Message"); } }
        public VictoryWindowViewModel(Player p)
        {
            player = p;
            if (p == null)
                message = "It's a draw!";
            else
                message = p.name + " wins the game!";
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

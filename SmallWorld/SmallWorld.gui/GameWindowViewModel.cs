using SmallWorld.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmallWorld.gui
{
    class GameWindowViewModel
    {
        public GameMaster GM { get; protected set; }

        private int selectedRow;
        public int SelectedRow { get { return selectedRow; } set { selectedRow = value;  OnPropertyChanged("SelectedRow"); } }
        private int selectedColumn;
        public int SelectedColumn { get { return selectedColumn; } set { selectedColumn = value; OnPropertyChanged("SelectedColumns"); } }
        private Visibility selectedVisible;
        public Visibility SelectedVisible { get { return selectedVisible; } set { selectedVisible = value; OnPropertyChanged("SelectedVisible"); } }

        public string firstPlayerName { get { return GM.game.gameSettings.playersNames[0]; } }
        public string firstPlayerScore { get { return GM.game.currentState.players[0].points.ToString(); } }
        public string secondPlayerName { get { return GM.game.gameSettings.playersNames[1]; } }
        public string secondPlayerScore { get { return GM.game.currentState.players[1].points.ToString(); } }

        public GameWindowViewModel(GameSettings settings)
        {
            GM = new GameMaster();
            GM.newGame(settings);
            SelectedRow = 0;
            SelectedColumn = 0;
            SelectedVisible = Visibility.Hidden;
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

using SmallWorld.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.gui
{
    /// <summary>
    /// Manage interfctions between the main window and the underline model
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public GameMaster GM { get; protected set; }
        public GameSettings GS { get; protected set; }

        public MainWindowViewModel()
        {
            GM = new GameMaster();
            GS = new GameSettings();

            // default builder - this match the interface parameters
            GS.mapType = MapType.Demo;
            GS.nbPlayers = 2;
            GS.playersNames.Add("Player1");
            GS.playersNames.Add("Player2");
            GS.playersRaces.Add(Races.Elf);
            GS.playersRaces.Add(Races.Human);
        }

        public string firstPlayerName {
            get { return GS.playersNames[0]; }
            set { GS.playersNames[0] = value; OnPropertyChanged("firstPlayerName"); } }


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

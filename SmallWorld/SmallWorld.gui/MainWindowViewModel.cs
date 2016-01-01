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

        public List<Races> firstPlayerRaces { get; set; }
        public List<Races> secondPlayerRaces { get; set; }

        public List<MapType> mapTypes { get; set; }

        public MainWindowViewModel()
        {
            GM = new GameMaster();
            GS = new GameSettings();

            firstPlayerRaces = new List<Races>() { Races.Elf, Races.Human, Races.Orc };
            secondPlayerRaces = new List<Races>() { Races.Elf, Races.Human, Races.Orc };
            mapTypes = new List<MapType>() { MapType.Demo, MapType.Small, MapType.Standard };

            // default builder - this match the interface parameters
            GS.mapType = MapType.Demo;
            GS.nbPlayers = 2;
            GS.playersNames.Add("Elrond");
            GS.playersRaces.Add(Races.Elf);
            GS.playersNames.Add("Aragorn");
            GS.playersRaces.Add(Races.Human);
        }

        public string firstPlayerName {
            get { return GS.playersNames[0]; }
            set { GS.playersNames[0] = value; OnPropertyChanged("firstPlayerName"); } }

        public Races firstPlayerRace {
            get
            {
                return GS.playersRaces[0];
            }
            set
            {
                GS.playersRaces[0] = value;
            }
        }

        public string secondPlayerName
        {
            get { return GS.playersNames[1]; }
            set { GS.playersNames[1] = value; OnPropertyChanged("secondPlayerName"); }
        }

        public Races secondPlayerRace
        {
            get
            {
                return GS.playersRaces[1];
            }
            set
            {
                GS.playersRaces[1] = value;
            }
        }

        public MapType mapType
        {
            get
            {
                return GS.mapType;
            }
            set
            {
                GS.mapType = value;
            }
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

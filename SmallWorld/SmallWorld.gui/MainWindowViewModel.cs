using SmallWorld.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace SmallWorld.gui
{
    /// <summary>
    /// Manage interactions between the main window and the underlying model
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public GameSettings GS { get; protected set; }

        public List<Races> firstPlayerRaces { get; set; }
        public List<Races> secondPlayerRaces { get; set; }
        public List<MapType> mapTypes { get; set; }

        public Races firstPlayerRace
        {
            get { return GS.playersRaces[0]; }
            set { GS.playersRaces[0] = value; OnPropertyChanged("firstPlayerRace"); }
        }
        public Races secondPlayerRace
        {
            get { return GS.playersRaces[1]; }
            set { GS.playersRaces[1] = value; OnPropertyChanged("secondPlayerRace"); }
        }

        public string firstPlayerName
        {
            get { return GS.playersNames[0]; }
            set { GS.playersNames[0] = value; OnPropertyChanged("firstPlayerName"); }
        }
        public string secondPlayerName
        {
            get { return GS.playersNames[1]; }
            set { GS.playersNames[1] = value; OnPropertyChanged("secondPlayerName"); }
        }

        public MapType mapType
        {
            get { return GS.mapType; }
            set { GS.mapType = value; OnPropertyChanged("mapType"); }
        }

        private ICommand startClick;
        public ICommand StartClick
        {
            get
            {
                if (startClick == null)
                    startClick = new RelayCommand(param => start_Click(), param => GS.areValid());
                return startClick;
            }
        }
        public void start_Click()
        {
            GS.setFieldsAccordingToMapType();
            GameWindow gameWindow = new GameWindow(GS);
            gameWindow.Show();
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
            LoadWindow win = new LoadWindow();
            win.Show();
        }

        private ICommand rulesClick;
        public ICommand RulesClick
        {
            get
            {
                if (rulesClick == null)
                    rulesClick = new RelayCommand(param => rules_Click(), param => true);
                return rulesClick;
            }
        }
        public void rules_Click()
        {
            HelpWindow win = new HelpWindow();
            win.Show();
        }

        public MainWindowViewModel()
        {
            GS = new GameSettings();

            firstPlayerRaces = new List<Races>() { Races.Elf, Races.Human, Races.Orc };
            secondPlayerRaces = new List<Races>() { Races.Elf, Races.Human, Races.Orc };
            mapTypes = new List<MapType>() { MapType.Demo, MapType.Small, MapType.Standard };

            // default builder - this match the interface parameters
            GS.mapType = MapType.Small;
            GS.nbPlayers = 2;
            GS.playersNames.Add("Elrond");
            GS.playersRaces.Add(Races.Elf);
            GS.playersNames.Add("Aragorn");
            GS.playersRaces.Add(Races.Human);
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

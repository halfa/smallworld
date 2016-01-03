using SmallWorld.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SmallWorld.gui
{
    class GameWindowViewModel : INotifyPropertyChanged
    {
        public GameMaster GM { get; protected set; }

        private int selectedRow;
        public int SelectedRow { get { return selectedRow; } set { selectedRow = value;  OnPropertyChanged("SelectedRow"); } }
        private int selectedColumn;
        public int SelectedColumn { get { return selectedColumn; } set { selectedColumn = value; OnPropertyChanged("SelectedColumns"); } }
        private Visibility selectedVisible;
        public Visibility SelectedVisible { get { return selectedVisible; } set { selectedVisible = value; OnPropertyChanged("SelectedVisible"); } }


        private AUnit selectedUnit { get { return GM.game.currentState.selectedUnit; } }
        private AUnit defaultUnit = new HumanUnit();

        private string selectedUnitAttack;
        public string SelectedUnitAttack { get { return selectedUnitAttack; } set { selectedUnitAttack = value; OnPropertyChanged("SelectedUnitAttack"); } }
        private string selectedUnitDefence;
        public string SelectedUnitDefence { get { return selectedUnitDefence; } set { selectedUnitDefence = value; OnPropertyChanged("SelectedUnitDefence"); } }
        private string selectedUnitHealth;
        public string SelectedUnitHealth { get { return selectedUnitHealth; } set { selectedUnitHealth = value; OnPropertyChanged("SelectedUnitHealth"); } }
        private string selectedUnitPool;
        public string SelectedUnitPool { get { return selectedUnitPool; } set { selectedUnitPool = value; OnPropertyChanged("SelectedUnitPool"); } }

        public string firstPlayerName { get { return GM.game.gameSettings.playersNames[0]; } }
        public string firstPlayerScore { get { return GM.game.currentState.players[0].points.ToString(); } }
        public string secondPlayerName { get { return GM.game.gameSettings.playersNames[1]; } }
        public string secondPlayerScore { get { return GM.game.currentState.players[1].points.ToString(); } }

        public string currentTurnCounter {  get { return GM.game.currentState.turnCounter.ToString(); } }
        public string maxTurnCounter { get { return GM.game.gameSettings.turnLimit.ToString(); } }

        public GameWindowViewModel(GameSettings settings)
        {
            GM = new GameMaster();
            GM.newGame(settings);
            SelectedRow = 0;
            SelectedColumn = 0;
            SelectedVisible = Visibility.Visible;

            defaultUnit.attackPt = 0;
            defaultUnit.defencePt = 0;
            defaultUnit.actionPool = 0;
            defaultUnit.healthPt = 0;

            updateSelectedUnitFields();
        }

        private void updateSelectedUnitFields()
        {
            AUnit unit = selectedUnit;

            if(unit == null)
                unit = defaultUnit;
            SelectedUnitAttack = unit.attackPt.ToString();
            SelectedUnitDefence = unit.defencePt.ToString();
            SelectedUnitHealth = unit.healthPt.ToString();
            SelectedUnitPool = unit.actionPool.ToString();
        }

        public void selectUnitAt(int column, int row)
        {
            GM.game.selectUnitAt(new Position(column, row));
            updateSelectedUnitFields();
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

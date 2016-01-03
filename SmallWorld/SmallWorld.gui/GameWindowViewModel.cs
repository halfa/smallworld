﻿using SmallWorld.Core;
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

        public string firstPlayerName;
        public string FirstPlayerName { get { return firstPlayerName; } set { firstPlayerName = value; OnPropertyChanged("FirstPlayerName"); } }
        private string firstPlayerScore;
        public string FirstPlayerScore { get { return firstPlayerScore; } set { firstPlayerScore = value; OnPropertyChanged("FirstPlayerScore"); } }

        public string secondPlayerName;
        public string SecondPlayerName { get { return secondPlayerName; } set { secondPlayerName = value; OnPropertyChanged("SecondPlayerName"); } }
        private string secondPlayerScore;
        public string SecondPlayerScore { get { return secondPlayerScore; } set { secondPlayerScore = value; OnPropertyChanged("SecondPlayerScore"); } }

        private string currentTurnCounter;
        public string CurrentTurnCounter { get { return currentTurnCounter; } set { currentTurnCounter = value;  OnPropertyChanged("CurrentTurnCounter"); } }
        private string maxTurnCounter;
        public string MaxTurnCounter { get { return maxTurnCounter; } set { maxTurnCounter = value;  OnPropertyChanged("MaxTurnCounter"); } }

        public AUnit SelectedUnit { get { return GM.game.currentState.selectedUnit; } }
        private AUnit defaultUnit;

        private string selectedUnitAttack;
        public string SelectedUnitAttack { get { return selectedUnitAttack; } set { selectedUnitAttack = value; OnPropertyChanged("SelectedUnitAttack"); } }
        private string selectedUnitDefence;
        public string SelectedUnitDefence { get { return selectedUnitDefence; } set { selectedUnitDefence = value; OnPropertyChanged("SelectedUnitDefence"); } }
        private string selectedUnitHealth;
        public string SelectedUnitHealth { get { return selectedUnitHealth; } set { selectedUnitHealth = value; OnPropertyChanged("SelectedUnitHealth"); } }
        private string selectedUnitPool;
        public string SelectedUnitPool { get { return selectedUnitPool; } set { selectedUnitPool = value; OnPropertyChanged("SelectedUnitPool"); } }

        private Visibility selectedVisible;
        public Visibility SelectedVisible { get { return selectedVisible; } set { selectedVisible = value; OnPropertyChanged("SelectedVisible"); } }

        public GameWindowViewModel(GameSettings settings)
        {
            GM = new GameMaster();
            GM.newGame(settings);

            FirstPlayerName = GM.game.currentState.players[0].name;
            FirstPlayerScore = GM.game.currentState.players[0].points.ToString();
            SecondPlayerName = GM.game.currentState.players[1].name;
            SecondPlayerScore = GM.game.currentState.players[1].points.ToString();

            CurrentTurnCounter = GM.game.currentState.turnCounter.ToString();
            MaxTurnCounter = GM.game.gameSettings.turnLimit.ToString();

            defaultUnit = new HumanUnit();
            defaultUnit.attackPt = 0;
            defaultUnit.defencePt = 0;
            defaultUnit.actionPool = 0;
            defaultUnit.healthPt = 0;

            updateSelectedUnitFields();
            SelectedVisible = Visibility.Hidden;
        }

        private void updateSelectedUnitFields()
        {
            AUnit unit = SelectedUnit;

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

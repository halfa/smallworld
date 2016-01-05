using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.gui
{
    class HelpWindowViewModel : INotifyPropertyChanged
    {

        private string generalRules;
        public string GeneralRules { get { return generalRules; } set { generalRules = value; OnPropertyChanged("GeneralRules"); } }

        private string armiesRules;
        public string ArmiesRules { get { return armiesRules; } set { armiesRules = value; OnPropertyChanged("ArmiesRules"); } }

        private string victoryRules;
        public string VictoryRules { get { return victoryRules; } set { victoryRules = value; OnPropertyChanged("VictoryRules"); } }

        private string pointsRules;
        public string PointsRules { get { return pointsRules; } set { pointsRules = value; OnPropertyChanged("PointsRules"); } }

        private string battleRules;
        public string BattleRules { get { return battleRules; } set { battleRules = value; OnPropertyChanged("BattleRules"); } }

        public HelpWindowViewModel()
        {
            GeneralRules = "Welcome to SmallWorld!\n\nIn SmallWorld, YOU, as the leader of your armies, will conquer countless lands and defeat your enemies!\nYou may chose your faction amongst Elves, Humans, and Orcs, but keep in mind that only DIFFERENT factions can face each other.\n\nA game takes place on a MAP, with a LIMITED amount of TURNS to achieve victory. Each player may play during his turn, and validate his actions by pressing the END TURN button.\nDon't worry though: if you've made a mistake, you can cancel your previous actions by pressing the UNDO button, but if you validate your turn, there is no turning back!\n\nYou may save your game at any time, after all, every great leader has dozens of matters to attend to.\nTo do so, use the SAVE command available on the menu bar, at the top of the game window. You may also return to the battlefield, and LOAD a previous battle by using the associated command.\nFinally, if you hesitate in deciding what orders to give to a specific unit, try to discuss the matter with your council, using the SUGGEST MOVE command. Their advices may be valuable (or not, you're the one leading after all).\n\nYou are now ready to take part in the upcoming war! However, consider spending some time reading the reports from your spies, which are labeled \"Armies\", \"Victory\", \"Points\", and \"Battle\".\nIt is true that soldiers win battles, but to win the war, one has to know his strenghts and weaknesses!\n\nEnjoy playing SmallWorld!";
            ArmiesRules = "Armies rules.";
            VictoryRules = "Victory rules.";
            PointsRules = "Points rules.";
            BattleRules = "Battle rules.";
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

using System.ComponentModel;

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
            GeneralRules = "Welcome to SmallWorld!\n\nIn SmallWorld, YOU, as the leader of your armies, will conquer countless lands and defeat your enemies!\nYou may chose your faction amongst Elves, Humans, and Orcs, but keep in mind that only DIFFERENT factions can face each other.\n\nA game takes place on a MAP, with a LIMITED amount of TURNS to achieve victory. Each player may play during his turn, and validate his actions by pressing the END TURN button.\nDon't worry though: if you've made a mistake, you can cancel your previous actions by pressing the UNDO button, but if you validate your turn, there is no turning back!\n\nYou may save your game at any time, after all, every great leader has dozens of matters to attend to.\nTo do so, use the SAVE command available on the menu bar, at the top of the game window. You may also return to the battlefield, and LOAD a previous battle by using the associated command.\nFinally, if you hesitate in deciding what orders to give to a specific unit, try to discuss the matter with your councelors, using the SUGGEST MOVE command. Their advices may be valuable (or not, you're the one leading after all).\n\nYou are now ready to take part in the upcoming war! However, consider spending some time reading the reports from your spies, which are labeled \"Armies\", \"Victory\", \"Points\", and \"Battle\".\nIt is true that soldiers win battles, but to win the war, one has to know his strenghts and weaknesses!\n\nEnjoy playing SmallWorld!";
            ArmiesRules = "To command your armies, you may select units using the MOUSE LEFT click, then select a destination with the MOUSE RIGHT click. If the selected unit can move to the specified location, it will. Note that you can select enemy units aswell, to get intel about their stats.\nIf you want your warriors to engage an enemy unit, simply select your army, and RIGHT CLICK on the enemy units.\n\nYou may position several units on the same terrain tile. To select a specific unit amongst several on the same tile, simply use the MOUSE LEFT click repeatedly, which will circle through the available units at that location.\n\nYour warriors have four stats: ATTACK, DEFENCE, HEALTH and ACTION. For details about ATTACK, DEFENCE and ACTION, see the \"Battle\" report.\n\nElven units:\nAttack: 4  Defence: 3\nHealth: 12  Action: 2\nRange: 2 on all terrains.\nCANNOT cross water.\nMoving to mountain terrain costs 2 action points.\n\nHuman units:\nAttack: 6  Defence: 3\nHealth: 15  Action: 2\nRange: 1 on all terrains.\nCAN cross water.\n\nOrc units:\nAttack: 5  Defence: 2\nHealth: 17  Action: 2\nRange: 1 on forest and plain terrains, 2 on mountain terrains.\nCANNOT cross water.\nMoving to plain terrain costs 0.5 action points.\n\nMoving to an adjacent tile costs 1 action point, see the exception rules above.\nPerforming an attack costs 1 action point.\n\nThe units replenish their action pool at the end of each game turn.";
            VictoryRules = "There are two ways of winning a game of SmallWorld: either by points, or supremacy.\n\nVictory by points:\nAt the end of the last turn, the victory points of the two players are compared. The player with the most points wins the game. If both players have the same amount of points, a draw is stated.\nSee the \"Points\" report for details about how to earn victory points.\n\nVictory by supremacy:\nIf a player's army has fallen during the game, the other player wins the game. No draw can be stated in a supremacy victory.";
            PointsRules = "Units earn points at the end of each GAME TURN (ie after the last player to play ended his turn).\nDifferent units earn different amounts of points on different terrains.\n\nElven units:\nForest: 3  Mountain: 0\nPlain: 1\n\nHuman units:\nForest: 1  Mountain: 1\nPlain: 2  Water: 0\n\nOrc units:\nForest: 1  Mountain: 2\nPlain: 1\n\nIf several units control the same terrain, victory points will only be earned once for all the present units.";
            BattleRules = "A battle result in the defender losing HEALTH, DEFENCE, and eventually die.\nIf the defender units died, that the attacker performed a MELEE attack (ie range on current terrain is 1), and that there is no more enemy units at the target tile, the attacker moves to the said tile FOR FREE (ie costs 0 ACTION points).\n\nPerforming an attack costs 1 ACTION point.\n\nCalculus for the attacks:\n\nThe effective attack damage is randomly chosen within the range:\n[70% x Unit Base Attack ; 130% x Unit Base Attack]\nThe attacker then has a 4% CRIT chance, resulting in doubling the effective attack damage.\nThe defender then loses HEALTH: effective attack damage - Defender Unit Base DEFENCE.\nThe defender also loses 1 DEFENCE point, since he sustained an attack, and is now weakened.\nHowever, the defender has a 4% HEROIC DEFENCE chance, resulting in not losing HEALTH nor DEFENCE, and GAINING 1 DEFENCE point.\n\nExample:\nA Human unit performs an attack at an Orc unit.\nIt costs him 1 ACTION point (now at 1).\nThe Human effective damage is randomly chosen within [70% x 6 ; 130% x 6] = [4 ; 8]\nLet's says that he got lucky, and rolled a 7.\nUnfortunatly for him, he did not roll a critical strike.\nThe defender unit tries to evade the attack.\nUnfortunatly, his efforts are in vain and he gets hit.\nHe then loses 7 - 2 = 5 HEALTH points (now at 12).\nHe also loses 1 DEFENCE points, (now at 1).\nThe defender holds with difficulty, but didn't die in the encounter.\nThe attacker does NOT move to the defender's location.\nEncounter ends.";
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBasedSuccessGames
{
    [Serializable]
    public class SimpleGame
    {
        public int MaxStages { get; set; }
        public int StartingBankroll { get; set; }

        public int ObjectiveBankroll { get; set; }

        public List<ISimpleGamble> Gambles { get; set; }

        public enum Objectives
        {
            Reachability = 1,
            Safety = 0
        }

        public Objectives Objective { get; set; }

        public Func<int, int, ISimpleGamble> ForcedGamble = null;
        public Func<int, int> DynamicEscapeBankroll = null;

        public SimpleGame(int maxStages, int startingBankroll, int objectiveBankroll, Objectives objective)
        {
            MaxStages = maxStages;
            StartingBankroll = startingBankroll;
            ObjectiveBankroll = objectiveBankroll;
            Objective = objective;
            Gambles = new List<ISimpleGamble>();
            EscapeBankroll = Math.Max(startingBankroll, objectiveBankroll);
            ForcedGamble = null;
        }

        public int EscapeBankroll { get; set; }
    }
}

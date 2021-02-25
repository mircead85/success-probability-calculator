using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBasedSuccessGames
{
    [Serializable]
    public class SimpleGamble : ISimpleGamble
    {
        public SimpleGamble(int entryFee)
        {
            EntryFee = entryFee;
            Outcomes = new List<Tuple<int, double>>();
            totalProbability = 0;
        }

        protected double totalProbability;

        public bool AddOutcome(int gain, double probability)
        {
            if (totalProbability >= 1)
                return false;

            if (probability + totalProbability > 1 || probability <= 0)
                return false;

            Outcomes.Add(new Tuple<int, double>(gain, probability));
            totalProbability += probability;
            return true;
        }

        public int EntryFee
        {
            get;
            protected set;
        }

        public List<Tuple<int, double>> Outcomes
        {
            get;
            protected set;
        }
    }
}

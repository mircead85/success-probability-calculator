using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBasedSuccessGames.SpecificGambles
{
    [Serializable]
    public class ExpensesGamble : SimpleGamble
    {
        public ExpensesGamble(int amount)
            : base(amount)
        {
            AddOutcome(0, 1);
        }

        public override string ToString()
        {
            return "EXPENSES: " + (EntryFee / 10.0).ToString()+"$";
        }
    }
}

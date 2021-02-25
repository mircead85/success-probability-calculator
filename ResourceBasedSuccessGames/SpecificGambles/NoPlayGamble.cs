using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBasedSuccessGames.SpecificGambles
{
    [Serializable]
    public class NoPlayGamble:ExpensesGamble
    {
        public NoPlayGamble() : base(0) { }

        public override string ToString()
        {
            return "NOPLAY";
        }
    }
}

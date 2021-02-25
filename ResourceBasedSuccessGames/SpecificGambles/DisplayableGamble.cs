using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBasedSuccessGames.SpecificGambles
{

    [Serializable]
    public abstract class DisplayableGamble : SimpleGamble, IDisplayableGamble
    {
        public DisplayableGamble(int entryFee) : base(entryFee) { }

        public virtual string Kind
        {
            get
            {
                return "Abstract gamble";
            }
        }


        public virtual double Stake
        {
            get;
            set;
        }

        public virtual double Rake
        {
            get;
            set;
        }

        public virtual double ROI
        {
            get;
            set;
        }

        public virtual double ProbabilityWin
        {
            get;
            set;
        }
    }
}

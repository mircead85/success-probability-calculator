using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBasedSuccessGames.SpecificGambles
{

    [Serializable]
    public class HeadsUpGamble : DisplayableGamble
    {
        public HeadsUpGamble(double stake, double rake, bool RakeIncluded)
            : this(stake, rake, RakeIncluded, 0)
        {
        }

        public HeadsUpGamble(double stake, double rake, bool RakeIncluded, double roi)
            : base(RakeIncluded ? (int)(10*stake) : (int)(10*(stake + rake)))
        {
            Stake = stake;
            if (!RakeIncluded)
                Stake += rake;
            Rake = rake;
            ROI = roi;
            Recompute();
        }

        protected void Recompute()
        {
            Outcomes.Clear();
            totalProbability = 0;
            AddOutcome((int)(2 * 10 * (Stake - Rake)), _ProbabilityWin);
            AddOutcome(0, 1 - _ProbabilityWin);
        }

        public static double getProbability(double roiV, double rakePercentage)
        {
            double result = (1 + roiV) / (2.0 * (1 - rakePercentage));
            return result;
        }

        protected double _ROI;

        public override double ROI
        {
            get
            {
                return _ROI;
            }
            set
            {
                var prob = getProbability(value, Rake / Stake);
                if (prob < 0 || prob > 1)
                    throw new ArgumentException("Invalid ROI for this game.");
                _ROI = value;
                _ProbabilityWin = prob;
                Recompute();
            }
        }

        public override double Stake { get; set; }
        public override double Rake { get; set; }

        protected double _ProbabilityWin;

        public override double ProbabilityWin
        {
            get
            {
                return _ProbabilityWin;
            }
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentException("Invalid probability");

                _ProbabilityWin = value;
                _ROI = _ProbabilityWin * 2 * (Stake - Rake) / Stake - 1.0;
                Recompute();
            }
        }

        public override string ToString()
        {
            return
                string.Format("{0}$ + {1}$ HU", (((int)((Stake - Rake) * 10)) / 10.0).ToString(), (((int)(Rake * 10)) / 10.0).ToString());
        }

        public static string MyKind
        {
            get
            {
                return "Heads-Up Match";
            }
        }

        public override string Kind
        {
            get
            {
                return "Heads-Up Match";
            }
        }
    }
}

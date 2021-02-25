using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBasedSuccessGames.SpecificGambles
{
    interface IDisplayableGamble
    {
        double Stake { get; }
        double Rake { get; }

        double ROI { get; }
        double ProbabilityWin { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBasedSuccessGames
{
    public interface ISimpleGamble
    {
        int EntryFee { get; }

        List<Tuple<int, double>> Outcomes { get; }
    }
}

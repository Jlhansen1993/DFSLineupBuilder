using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Models
{
    public class NHLTeam
    {
        public string Team { get; set; }
        public double TeamImpliedTotal { get; set; }
        public string Opponent { get; set; }

    }
    
    public class NHLTeamList : List<NHLTeam> { }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Utilities
{
    public class NHLUtils
    {
        public static string ConvertRotowireTeamAbbreviation(string team)
        {
            switch(team)
            {
                case "ANH":
                    return "ANA";
                case "VGK":
                    return "VGS";
                default:
                    return team;
            }
        }

    }
}

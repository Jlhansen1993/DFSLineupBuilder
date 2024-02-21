using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Models
{
    public class NHLProjection
    {   
        public string Position { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public int Salary { get; set; }
        public double PFP { get; set; }
    }

    public class NHLProjectionList : List<NHLProjection> { }
}

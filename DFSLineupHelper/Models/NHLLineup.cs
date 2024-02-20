using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Models
{
    public class NHLLineup
    {
        public (string Position, string Name, string Team, int Salary, double PFP) C1 { get; set; }
        public (string Position, string Name, string Team, int Salary, double PFP) C2 { get; set; }
        public (string Position, string Name, string Team, int Salary, double PFP) W1 { get; set; }
        public (string Position, string Name, string Team, int Salary, double PFP) W2 { get; set; }
        public (string Position, string Name, string Team, int Salary, double PFP) D1 { get; set; }
        public (string Position, string Name, string Team, int Salary, double PFP) D2 { get; set; }
        public (string Position, string Name, string Team, int Salary, double PFP) UTIL2 { get; set; }
        public (string Position, string Name, string Team, int Salary, double PFP) UTIL1 { get; set; }
        public (string Position, string Name, string Team, int Salary) G { get; set; }
        public int TotalSalary { get; set; }
        public double TotalPFP { get; set; }
    }
}

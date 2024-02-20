using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Models
{
    public class NHLGame
    {
        public string AwayTeam { get; set; }
        public double AwayTeamImpliedTotal { get; set; }
        public string HomeTeam { get; set; }
        public double HomeTeamImpliedTotal { get; set; }
        public (string Position, string Name, int Salary) AwayGoalie { get; set; }
        public (string Position, string Name, int Salary) HomeGoalie { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S1 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S2 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S3 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S4 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S5 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S6 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S7 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S8 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S9 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Away_S10 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S1 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S2 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S3 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S4 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S5 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S6 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S7 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S8 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S9 { get; set; }
        public (string Position, string Name, int Salary, double PFP) Home_S10 { get; set; }
    }
    
    public class NHLGameList : List<NHLGame> { }
}

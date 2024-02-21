using DFSLineupHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Utilities
{
    public class NHLUtils
    {
        public static NHLProjectionList BuildNHLLineup(NHLProjectionList projections)
        {
            // Create an empty list to hold the lineup.
            NHLProjectionList currentLineup = new NHLProjectionList();

            // Order list by PFP.
            projections.Sort((p1, p2) => p2.PFP.CompareTo(p1.PFP));

            // Select the goalie.
            currentLineup.Add(projections.Where(p => p.Position == "G").FirstOrDefault());

            // Remove goalies from the projections list.
            projections.RemoveAll(p => p.Position == "G");

            // Create a new projections list to work off of.
            NHLProjectionList masterUpdatedProjections = new NHLProjectionList();

            // Loop through each current projection.
            foreach(NHLProjection projection in projections)
            {
                // Add the normal position to the updated list.
                masterUpdatedProjections.Add(new NHLProjection() { Position = projection.Position, Name = projection.Name, Team = projection.Team, Salary = projection.Salary, PFP = projection.PFP});

                // Add the util position to the updated list.
                masterUpdatedProjections.Add(new NHLProjection() { Position = "UTIL", Name = projection.Name, Team = projection.Team, Salary = projection.Salary, PFP = projection.PFP });
            }

            // Create a dictionary of positions.
            Dictionary<string, int> positionCount = new Dictionary<string, int>();

            // Create a dictionary of teams.
            Dictionary<string, int> teamCount = new Dictionary<string, int>();     

            // Add goalie to the position count.
            positionCount.Add("G", 1);

            // Add goalie team to the team count.
            teamCount.Add(currentLineup[0].Team, 1);

            // Do until lineup count is 9.
            while (currentLineup.Count <= 8)
            {
                // Define a temp projection list.
                NHLProjectionList tempProjections = masterUpdatedProjections;

                // Remove players on the current lineup from projection list.
                foreach (NHLProjection projection in currentLineup)
                    tempProjections.RemoveAll(tp => tp.Name == projection.Name);

                // Loop through position count and remove positions that count = 2.
                foreach(var position in positionCount)
                    if(position.Value == 2)
                        tempProjections.RemoveAll(tp => tp.Position == position.Key);

                // Loop through team count and remove positions that count = 4.
                foreach (var team in teamCount)
                    if (team.Value == 4)
                        tempProjections.RemoveAll(tp => tp.Team == team.Key);

                // Define an empty selected projection.
                NHLProjection selectedProjection = new NHLProjection();

                // If less than 8 players on lineup.
                if (currentLineup.Count < 8)
                {
                    selectedProjection = tempProjections
                        .Where(p => (p.Salary + currentLineup.Sum(cl => cl.Salary)) <= 55000 &&
                                    ((55000 - (p.Salary + currentLineup.Sum(cl => cl.Salary))) / (9 - currentLineup.Count)) >= 3000)
                        .FirstOrDefault();
                }
                else
                {
                    selectedProjection = tempProjections
                        .Where(p => (p.Salary + currentLineup.Sum(cl => cl.Salary)) <= 55000)
                        .FirstOrDefault();
                }

                // Add player to lineup.
                currentLineup.Add(selectedProjection);

                // Update position count.
                if (positionCount.TryGetValue(selectedProjection.Position, out int count))
                {
                    // Key exists, increment the value by 1
                    positionCount[selectedProjection.Position] = count + 1;
                }
                else
                {
                    // Key doesn't exist, add a new key-value pair with the key and value 1
                    positionCount.Add(selectedProjection.Position, 1);
                }

                // Update position count.
                if (teamCount.TryGetValue(selectedProjection.Team, out int count2))
                {
                    // Key exists, increment the value by 1
                    teamCount[selectedProjection.Team] = count2 + 1;
                }
                else
                {
                    // Key doesn't exist, add a new key-value pair with the key and value 1
                    teamCount.Add(selectedProjection.Team, 1);
                }
            }


            // Return the current lineup.
            return currentLineup;
        }
    }
}

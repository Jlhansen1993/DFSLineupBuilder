using DFSLineupHelper.Adapters;
using DFSLineupHelper.Models;

#region // NHL DFS Lineup Tool 
// Define an empty lineup.
NHLLineup nhlLineup = new NHLLineup();

// Get todays NHL games.
NHLGameList nhlGames = NumberFireNHL.GetTodaysGames();

// Get todays NHL starting lines.
nhlGames = RotowireNHL.GetExpectedLineups(nhlGames);

// Get todays implied team totals.
nhlGames = NumberFireNHL.GetGameImpliedTotals(nhlGames);

// Get todays player projections.
nhlGames = DailyFantasyFuelNHL.GetPlayerProjections(nhlGames);

// Create list of implied goals.
List<(string Team, double ImpliedGoals)> impliedGoalsList = new List<(string Team, double ImpliedGoals)>();

// Loop through each game.
foreach(NHLGame game in nhlGames)
{
    // Add away team and implied goals to list.
    impliedGoalsList.Add((Team: game.AwayTeam, ImpliedGoals: game.AwayTeamImpliedTotal));

    // Add home team and implied goals to list.
    impliedGoalsList.Add((Team: game.HomeTeam, ImpliedGoals: game.HomeTeamImpliedTotal));
}

// Sort the impliedGoalsList by ImpliedGoals ascending.
impliedGoalsList.Sort((igl1, igl2) => igl1.ImpliedGoals.CompareTo(igl2.ImpliedGoals));

// Select the lowest implied goals above 0.0.
var lowestScore = impliedGoalsList.First(igl => igl.ImpliedGoals > 0.0);

// Find the game associated with the selected lowest score.
int lowestImpliedScoreGameIndex = nhlGames.FindIndex(g => g.HomeTeam == lowestScore.Team || g.AwayTeam == lowestScore.Team);

// Get data from the game.
if(lowestImpliedScoreGameIndex != -1)
{
    if (nhlGames[lowestImpliedScoreGameIndex].AwayTeam == lowestScore.Team)
    {
        // Add the goalie to the lineup.
        nhlLineup.G = (Position: nhlGames[lowestImpliedScoreGameIndex].HomeGoalie.Position, Name: nhlGames[lowestImpliedScoreGameIndex].HomeGoalie.Name, Team: nhlGames[lowestImpliedScoreGameIndex].HomeTeam, nhlGames[lowestImpliedScoreGameIndex].HomeGoalie.Salary);
        
        // Add the salary to the total salary.
        nhlLineup.TotalSalary += nhlGames[lowestImpliedScoreGameIndex].HomeGoalie.Salary;
    }
    else
    {
        // Add the goalie to the lineup.
        nhlLineup.G = (Position: nhlGames[lowestImpliedScoreGameIndex].AwayGoalie.Position, Name: nhlGames[lowestImpliedScoreGameIndex].AwayGoalie.Name, Team: nhlGames[lowestImpliedScoreGameIndex].AwayTeam, nhlGames[lowestImpliedScoreGameIndex].AwayGoalie.Salary);

        // Add the salary to the total salary.
        nhlLineup.TotalSalary += nhlGames[lowestImpliedScoreGameIndex].AwayGoalie.Salary;
    }
}

// Sort the impliedGoalsList by ImpliedGoals descinding.
impliedGoalsList.Sort((igl1, igl2) => igl2.ImpliedGoals.CompareTo(igl1.ImpliedGoals));

// Select the top team.
var highestScore = impliedGoalsList[0];

// Find the game associated with the selected highest score.
int highestImpliedScoreGameIndex = nhlGames.FindIndex(g => g.HomeTeam == highestScore.Team || g.AwayTeam == highestScore.Team);

// Create a list of the highest teams roster.
List<(string Position, string Name, string Team, int Salary, double PFP)> highestLineup = new List<(string Position, string Name, string Team, int Salary, double PFP)>();

// Get data from the game.
if (highestImpliedScoreGameIndex != -1)
{
    if (nhlGames[highestImpliedScoreGameIndex].AwayTeam == highestScore.Team)
    {
        // Create a list of all the players and their scores.


    }
    else
    {
        // Add the goalie to the lineup.
        nhlLineup.G = (Position: nhlGames[lowestImpliedScoreGameIndex].AwayGoalie.Position, Name: nhlGames[lowestImpliedScoreGameIndex].AwayGoalie.Name, Team: nhlGames[lowestImpliedScoreGameIndex].AwayTeam, nhlGames[lowestImpliedScoreGameIndex].AwayGoalie.Salary);

        // Add the salary to the total salary.
        nhlLineup.TotalSalary += nhlGames[lowestImpliedScoreGameIndex].AwayGoalie.Salary;
    }
}

bool test = false;


#endregion
using DFSLineupHelper.Adapters;
using DFSLineupHelper.Models;
using DFSLineupHelper.Utilities;

#region // NHL DFS Lineup Tool 
// Define an empty lineup.
NHLLineup nhlLineup = new NHLLineup();

// Get todays NHL games.
NHLTeamList nhlTeams = NumberFireNHL.GetTodaysGames();

// Get todays NHL starting lines.
// nhlGames = RotowireNHL.GetExpectedLineups(nhlGames);

// Get todays implied team totals.
nhlTeams = NumberFireNHL.GetImpliedTotals(nhlTeams);

// Get todays projections.
NHLProjectionList nhlProjections = NumberFireNHL.GetSkaterProjections();

// Get todays goalie projections.
nhlProjections = NumberFireNHL.GetGoalieProjections(projections: nhlProjections);

// Sort projections by pfp in desc order.
nhlProjections.Sort((p1, p2) => p2.PFP.CompareTo(p1.PFP));

// Build nhl csv.
NHLUtils.WriteProjectionsToCSV(nhlProjections);

// Get lineup.
// NHLProjectionList currentLineup = NHLUtils.BuildNHLLineup(nhlProjections);

// Get todays player projections.
//nhlGames = DailyFantasyFuelNHL.GetPlayerProjections(nhlGames);

bool test = false;


#endregion
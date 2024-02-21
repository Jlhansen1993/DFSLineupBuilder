using DFSLineupHelper.Models;
using DFSLineupHelper.Utilities;
using DFSLineupHelper.Constants;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Adapters
{
    public class NumberFireNHL
    {
        public static NHLTeamList GetTodaysGames()
        {
            // Define an empty nhl games list.
            NHLTeamList nhlTeams = new NHLTeamList();

            // Get html document from web page.
            HtmlDocument htmlDocument = WebScraper.ScrapeData(NHLConstants.NumberFireNHLScheduleURL);

            // Get a list of html nodes representing each NHL game today.
            HtmlNodeCollection gameCollection = htmlDocument.DocumentNode.SelectNodes(NHLConstants.NumberFireNHLScheduleXPath);

            // Loop through each game.
            foreach(HtmlNode game in gameCollection)
            {
                // Get away team.
                string awayTeam = game.SelectSingleNode(NHLConstants.NumberFireNHLScheduleAwayTeamXPath).InnerText;

                // Get home team.
                string homeTeam = game.SelectSingleNode(NHLConstants.NumberFireNHLScheduleHomeTeamXPath).InnerText;

                // Add the away team to the teams list.
                nhlTeams.Add(new NHLTeam()
                {
                    Team = awayTeam,
                    TeamImpliedTotal = 0,
                    Opponent = homeTeam
                });

                // Add the home team to the teams list.
                nhlTeams.Add(new NHLTeam()
                {
                    Team = homeTeam,
                    TeamImpliedTotal = 0,
                    Opponent = awayTeam
                });
            }

            // Return list of games generated.
            return nhlTeams; 
        }

        public static NHLTeamList GetImpliedTotals(NHLTeamList nhlTeams) 
        {
            // Get website data.
            HtmlDocument htmlDocument = WebScraper.ScrapeData(NHLConstants.NumberFireNHLTeamImpliedTotals);

            // Fill a node collection with rows.
            HtmlNodeCollection dataRows = htmlDocument.DocumentNode.SelectNodes(NHLConstants.NumberFireNHLTeamImpliedTotalsRowsXPath);

            // Loop through each row.
            foreach(HtmlNode dataRow in dataRows)
            {
                // Get the away team.
                string team = dataRow.SelectSingleNode(NHLConstants.NumberFireNHLTeamImpliedTotalsTeamXPath).InnerText.Trim();

                // Get team implied total.
                double teamImpliedTotal = Convert.ToDouble(dataRow.ChildNodes[7].InnerText);

                // Search through away teams to see if there is a game that matches.
                int teamIndex = nhlTeams.FindIndex(tl => tl.Team == team);

                // If there is a matching away team, add the data.
                if(teamIndex != -1)
                {
                    // Set the implied team total.
                    nhlTeams[teamIndex].TeamImpliedTotal = teamImpliedTotal;
                }
            }

            // Remove games missing implied team totals.
            nhlTeams.RemoveAll(g => g.TeamImpliedTotal == 0);

            // Return updated games list.
            return nhlTeams;
        }

        public static NHLProjectionList GetSkaterProjections()
        {
            // Define empty projection list.
            NHLProjectionList projections = new NHLProjectionList();

            // Get data from numberfire.
            HtmlDocument htmlDocument = WebScraper.ScrapeData(NHLConstants.NumberFireNHLSkaterProjectionsURL);

            // Get rows from site.
            HtmlNodeCollection projectionRows = htmlDocument.DocumentNode.SelectNodes(NHLConstants.NumberFireNHLProjectionsRowXPath);

            // Loop through each row.
            foreach(HtmlNode projectionRow in projectionRows)
            {
                // Get td nodes.
                HtmlNodeCollection tdNodes = projectionRow.SelectNodes("td");

                // Get position.
                string position = tdNodes[0].SelectSingleNode(".//*[@class='player-info--position']").InnerText;

                // Get name.
                string name = tdNodes[0].SelectSingleNode(".//*[@class='full']").InnerText.Replace("\n", "").Replace("\t", ""); ;

                // Get team.
                string team = tdNodes[0].SelectSingleNode(".//*[@class='team-player__team active']").InnerText.Replace("\n", "").Replace("\t", "");

                // Get salary.
                int salary = Convert.ToInt32(new string(tdNodes[2].InnerText.Where(char.IsDigit).ToArray()));

                // Get shots.
                double shots = Convert.ToDouble(tdNodes[4].InnerText.Replace("\n", "").Replace("\t", ""));

                // Get points.
                double points = Convert.ToDouble(tdNodes[7].InnerText.Replace("\n", "").Replace("\t", ""));

                // Get blocks.
                double blocks = Convert.ToDouble(tdNodes[11].InnerText.Replace("\n", "").Replace("\t", ""));

                // Total PFP.
                double totalPFP = shots + points + blocks;

                // Add projection to projections list.
                projections.Add(new NHLProjection() { Position = position, Name = name, Team = team, Salary = salary, PFP = totalPFP});

            }

            // Return projection list.
            return projections;
        }

        public static NHLProjectionList GetGoalieProjections(NHLProjectionList projections)
        {
            // Get data from numberfire.
            HtmlDocument htmlDocument = WebScraper.ScrapeData(NHLConstants.NumberFireNHLGoalieProjectionsURL);

            // Get rows from site.
            HtmlNodeCollection projectionRows = htmlDocument.DocumentNode.SelectNodes(NHLConstants.NumberFireNHLProjectionsRowXPath);

            // Loop through each row.
            foreach (HtmlNode projectionRow in projectionRows)
            {
                // Get td nodes.
                HtmlNodeCollection tdNodes = projectionRow.SelectNodes("td");

                // Get position.
                string position = "G";

                // Get name.
                string name = tdNodes[0].SelectSingleNode(".//*[@class='full']").InnerText.Replace("\n", "").Replace("\t", ""); ;

                // Get team.
                string team = tdNodes[0].SelectSingleNode(".//*[@class='team-player__team active']").InnerText.Replace("\n", "").Replace("\t", "");

                // Get salary.
                int salary = Convert.ToInt32(new string(tdNodes[2].InnerText.Where(char.IsDigit).ToArray()));

                // Get goals allowed.
                double goalsAllowed = Convert.ToDouble(tdNodes[4].InnerText.Replace("\n", "").Replace("\t", "")) * 4;

                // Get saves.
                double saves = Convert.ToDouble(tdNodes[6].InnerText.Replace("\n", "").Replace("\t", ""));

                // Get shutout.
                double shutOut = Convert.ToDouble(tdNodes[7].InnerText.Replace("\n", "").Replace("\t", ""));

                // Get wins.
                double wins = Convert.ToDouble(tdNodes[8].InnerText.Replace("\n", "").Replace("\t", ""));

                // Total PFP.
                double totalPFP = (saves + shutOut + wins) / goalsAllowed;

                // Add projection to projections list.
                projections.Add(new NHLProjection() { Position = position, Name = name, Team = team, Salary = salary, PFP = totalPFP });

            }

            // Return projection list.
            return projections;
        }
    }
}

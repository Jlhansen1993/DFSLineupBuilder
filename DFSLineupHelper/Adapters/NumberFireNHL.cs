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
        public static NHLGameList GetTodaysGames()
        {
            // Define an empty nhl games list.
            NHLGameList nhlGames = new NHLGameList();

            // Get html document from web page.
            HtmlDocument htmlDocument = WebScraper.ScrapeData(NHLConstants.NumberFireNHLScheduleURL);

            // Get a list of html nodes representing each NHL game today.
            HtmlNodeCollection gameCollection = htmlDocument.DocumentNode.SelectNodes(NHLConstants.NumberFireNHLScheduleXPath);

            // Loop through each game.
            foreach(HtmlNode game in gameCollection)
            {
                // Define an empty NHLGame object.
                NHLGame nhlGame = new NHLGame();

                // Get away team.
                string awayTeam = game.SelectSingleNode(NHLConstants.NumberFireNHLScheduleAwayTeamXPath).InnerText;

                // Get home team.
                string homeTeam = game.SelectSingleNode(NHLConstants.NumberFireNHLScheduleHomeTeamXPath).InnerText;

                // Fill the nhlGame object.
                nhlGame.AwayTeam = awayTeam;
                nhlGame.HomeTeam = homeTeam;

                // Add the game to the games list.
                nhlGames.Add(nhlGame);
            }

            // Return list of games generated.
            return nhlGames; 
        }

        public static NHLGameList GetGameImpliedTotals(NHLGameList nhlGames) 
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
                int awayTeamGameIndex = nhlGames.FindIndex(gl => gl.AwayTeam == team);

                // Search through home teams to see if there is a game that matches.
                int homeTeamGameIndex = nhlGames.FindIndex(gl => gl.HomeTeam == team);

                // If there is a matching away team, add the data.
                if(awayTeamGameIndex != -1)
                {
                    // Set the implied team total.
                    nhlGames[awayTeamGameIndex].AwayTeamImpliedTotal = teamImpliedTotal;
                }
                else
                {
                    // Set the home teams implied team total.
                    nhlGames[homeTeamGameIndex].HomeTeamImpliedTotal = teamImpliedTotal;
                }
            }

            // Remove games missing implied team totals.
            nhlGames.RemoveAll(g => g.HomeTeamImpliedTotal == 0 && g.AwayTeamImpliedTotal == 0);

            // Return updated games list.
            return nhlGames;
        }
    }
}

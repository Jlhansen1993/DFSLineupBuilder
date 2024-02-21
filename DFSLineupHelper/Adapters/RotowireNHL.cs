using DFSLineupHelper.Constants;
using DFSLineupHelper.Models;
using DFSLineupHelper.Utilities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Adapters
{
    public class RotowireNHL
    {
        /*public static NHLTeamList GetExpectedLineups(NHLTeamList nhlGames)
        {
            // Scrape data from website.
            HtmlDocument htmlDocument = WebScraper.ScrapeData(NHLConstants.RotowireNHLStartingLinesURL);

            // Get games list.
            HtmlNodeCollection gamesList = htmlDocument.DocumentNode.SelectNodes(NHLConstants.RotowireNHLStartingLinesGameXPath);

            // Loop through each game.
            foreach (HtmlNode game in gamesList)
            {
                // Get away lineup.
                HtmlNode awayLineup = game.SelectSingleNode(NHLConstants.RotowireNHLStartingLinesAwayTeamXPath);

                // Get home lineup.
                HtmlNode homeLineup = game.SelectSingleNode(NHLConstants.RotowireNHLStartingLinesHomeTeamXPath);

                // Get away starting goalie.
                string awayGoalie = awayLineup.SelectSingleNode(NHLConstants.RotowireNHLStartingGoalieXPath).InnerText;

                // Get home starting goalie.
                string homeGoalie = homeLineup.SelectSingleNode(NHLConstants.RotowireNHLStartingGoalieXPath).InnerText;

                

            // Return the update NHL games list.
            return nhlGames;
        }*/
    }
}
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
        public static NHLGameList GetExpectedLineups(NHLGameList nhlGames)
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

                // Get away line data.
                List<HtmlNode> awaySkaters = awayLineup
                    .SelectNodes(NHLConstants.RotowireNHLStartingSkaterXPath)
                    .Take(10)
                    .ToList();

                // Get home line data.
                List<HtmlNode> homeSkaters = homeLineup
                    .SelectNodes(NHLConstants.RotowireNHLStartingSkaterXPath)
                    .Take(10)
                    .ToList();

                // Find away team and home team.
                string awayTeam = NHLUtils.ConvertRotowireTeamAbbreviation(game.SelectSingleNode(NHLConstants.RotowireNHLAwayTeam).InnerText);
                string homeTeam = NHLUtils.ConvertRotowireTeamAbbreviation(game.SelectSingleNode(NHLConstants.RotowireNHLHomeTeam).InnerText);

                // Get game index for the away and home team combo.
                int gameIndex = nhlGames.FindIndex(g => g.AwayTeam == awayTeam && g.HomeTeam == homeTeam);

                // Define away team lines.
                nhlGames[gameIndex].AwayGoalie = ("G", awayGoalie, 0);
                nhlGames[gameIndex].Away_S1 = ("", awaySkaters[0].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Away_S2 = ("", awaySkaters[1].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Away_S3 = ("", awaySkaters[2].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Away_S4 = ("", awaySkaters[3].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Away_S5 = ("", awaySkaters[4].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Away_S6 = ("", awaySkaters[5].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Away_S7 = ("", awaySkaters[6].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Away_S8 = ("", awaySkaters[7].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Away_S9 = ("", awaySkaters[8].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Away_S10 = ("", awaySkaters[9].GetAttributeValue("title", ""), 0, 0);
                // nhlGames[gameIndex].AwayPPL1 = (("", awaySkaters[0].GetAttributeValue("title", ""), 0), ("", awaySkaters[1].GetAttributeValue("title", ""), 0), ("", awaySkaters[2].GetAttributeValue("title", ""), 0), ("", awaySkaters[3].GetAttributeValue("title", ""), 0), ("", awaySkaters[4].GetAttributeValue("title", ""), 0));
                // nhlGames[gameIndex].AwayPPL2 = (("", awaySkaters[5].GetAttributeValue("title", ""), 0), ("", awaySkaters[6].GetAttributeValue("title", ""), 0), ("", awaySkaters[7].GetAttributeValue("title", ""), 0), ("", awaySkaters[8].GetAttributeValue("title", ""), 0), ("", awaySkaters[9].GetAttributeValue("title", ""), 0));

                // Define home team lines.
                nhlGames[gameIndex].HomeGoalie = ("G", homeGoalie, 0);
                nhlGames[gameIndex].Home_S1 = ("", homeSkaters[0].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Home_S2 = ("", homeSkaters[1].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Home_S3 = ("", homeSkaters[2].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Home_S4 = ("", homeSkaters[3].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Home_S5 = ("", homeSkaters[4].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Home_S6 = ("", homeSkaters[5].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Home_S7 = ("", homeSkaters[6].GetAttributeValue("title", ""), 0, 0);   
                nhlGames[gameIndex].Home_S8 = ("", homeSkaters[7].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Home_S9 = ("", homeSkaters[8].GetAttributeValue("title", ""), 0, 0);
                nhlGames[gameIndex].Home_S10 = ("", homeSkaters[9].GetAttributeValue("title", ""), 0, 0);
                // nhlGames[gameIndex].HomePPL1 = (("", homeSkaters[0].GetAttributeValue("title", ""), 0), ("", homeSkaters[1].GetAttributeValue("title", ""), 0), ("", homeSkaters[2].GetAttributeValue("title", ""), 0), ("", homeSkaters[3].GetAttributeValue("title", ""), 0), ("", homeSkaters[4].GetAttributeValue("title", ""), 0));
                // nhlGames[gameIndex].HomePPL2 = (("", homeSkaters[5].GetAttributeValue("title", ""), 0), ("", homeSkaters[6].GetAttributeValue("title", ""), 0), ("", homeSkaters[7].GetAttributeValue("title", ""), 0), ("", homeSkaters[8].GetAttributeValue("title", ""), 0), ("", homeSkaters[9].GetAttributeValue("title", ""), 0));
            }

            // Return the update NHL games list.
            return nhlGames;
        }
    }
}
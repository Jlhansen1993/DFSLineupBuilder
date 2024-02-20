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
    public class DailyFantasyFuelNHL
    {
        public static NHLGameList GetPlayerProjections(NHLGameList nhlGames)
        {
            // Get data from web page.
            HtmlDocument htmlDocument = WebScraper.ScrapeData(NHLConstants.DailyFantasyFuelNHLURL);

            // Get projection rows.
            HtmlNodeCollection projectionRows = htmlDocument.DocumentNode.SelectNodes(NHLConstants.DailyFantasyFuelNHLProjectionsRowsXPath);

            // Loop through projections.
            foreach (HtmlNode row in projectionRows)
            {
                // Define name.
                string name = row.GetAttributeValue("data-name", "");

                // Define position.
                string position = row.GetAttributeValue("data-pos", "");

                // Define salary.
                int salary = Convert.ToInt32(row.GetAttributeValue("data-salary", ""));

                // Define PFP.
                double pfp = Convert.ToDouble(row.GetAttributeValue("data-ppg_proj", ""));

                // Temp correction
                if(name == "Spencer Martin")
                {
                    salary = 6500;
                }

                // Name corrections.
                switch (name)
                {
                    case "Alex Wennberg":
                        name = "Alexander Wennberg";
                        break;
                    case "Nick Paul":
                        name = "Nicholas Paul";
                        break;
                    case "A. Vasilevskiy":
                        name = "A. Vasilevskiy";
                        break;
                    default:
                        break;
                }

                // Loop through nhl games.
                foreach(NHLGame game in nhlGames)
                {
                    // Try to find player in away lineup.
                    if (game.AwayGoalie.Name == name)
                    {
                        // Update skater.
                        game.AwayGoalie = (Position: position, Name: name, Salary: salary);
                        break;
                    }
                    else if (game.Away_S1.Name == name)
                    {
                        // Update skater.
                        game.Away_S1 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Away_S2.Name == name)
                    {
                        // Update skater.
                        game.Away_S2 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Away_S3.Name == name)
                    {
                        // Update skater.
                        game.Away_S3 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Away_S4.Name == name)
                    {
                        // Update skater.
                        game.Away_S4 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Away_S5.Name == name)
                    {
                        // Update skater.
                        game.Away_S5 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Away_S6.Name == name)
                    {
                        // Update skater.
                        game.Away_S6 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Away_S7.Name == name)
                    {
                        // Update skater.
                        game.Away_S7 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Away_S8.Name == name)
                    {
                        // Update skater.
                        game.Away_S8 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Away_S9.Name == name)
                    {
                        // Update skater.
                        game.Away_S9 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Away_S10.Name == name)
                    {
                        // Update skater.
                        game.Away_S10 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }

                    // Try to find player in home lineup.
                    if (game.HomeGoalie.Name == name)
                    {
                        // Update skater.
                        game.HomeGoalie = (Position: position, Name: name, Salary: salary);
                        break;
                    }
                    else if(game.Home_S1.Name == name)
                    {
                        // Update skater.
                        game.Home_S1 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Home_S2.Name == name)
                    {
                        // Update skater.
                        game.Home_S2 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Home_S3.Name == name)
                    {
                        // Update skater.
                        game.Home_S3 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Home_S4.Name == name)
                    {
                        // Update skater.
                        game.Home_S4 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Home_S5.Name == name)
                    {
                        // Update skater.
                        game.Home_S5 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Home_S6.Name == name)
                    {
                        // Update skater.
                        game.Home_S6 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Home_S7.Name == name)
                    {
                        // Update skater.
                        game.Home_S7 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Home_S8.Name == name)
                    {
                        // Update skater.
                        game.Home_S8 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Home_S9.Name == name)
                    {
                        // Update skater.
                        game.Home_S9 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                    else if (game.Home_S10.Name == name)
                    {
                        // Update skater.
                        game.Home_S10 = (Position: position, Name: name, Salary: salary, PFP: pfp);
                        break;
                    }
                }
            }

            // Return updated games list.
            return nhlGames;
        }
    }
}

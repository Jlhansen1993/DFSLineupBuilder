using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Constants
{
    public class NHLConstants
    {
        // NumberFire NHL schedule url.
        public static string NumberFireNHLScheduleURL = "https://www.numberfire.com/nhl/games";

        // Game list xpath.
        public static string NumberFireNHLScheduleXPath = "//*[contains(@class, 'game-indiv--list')]";

        // Away team xpath.
        public static string NumberFireNHLScheduleAwayTeamXPath = ".//*[@class='team team--left']/div[1]/a/span[2]";

        // Home team xpath.
        public static string NumberFireNHLScheduleHomeTeamXPath = ".//*[@class='team team--right']/div[1]/a/span[2]";

        // Rotowire NHL starting lines.
        public static string RotowireNHLStartingLinesURL = "https://www.rotowire.com/hockey/nhl-lineups.php";

        // Rotowire NHL starting lines game box.
        public static string RotowireNHLStartingLinesGameXPath = ".//*[@class='lineup is-nhl']";

        // Rotowire NHL starting away lines.
        public static string RotowireNHLStartingLinesAwayTeamXPath = ".//*[@class='lineup__list is-visit']";

        // Rotowire NHL starting home lines.
        public static string RotowireNHLStartingLinesHomeTeamXPath = ".//*[@class='lineup__list is-home']";

        // Rotowire NHL starting goalie.
        public static string RotowireNHLStartingGoalieXPath = ".//*[@class='lineup__player-highlight']/div/a";

        // Rotowire NHL starting skater.
        public static string RotowireNHLStartingSkaterXPath = ".//*[@class='lineup__player']/a";

        // Rotowire NHL away team.
        public static string RotowireNHLAwayTeam = ".//*[@class='lineup__team is-visit']/div";

        // Rotowire NHL home team.
        public static string RotowireNHLHomeTeam = ".//*[@class='lineup__team is-home']/div";

        // NumberFire NHL implied totals.
        public static string NumberFireNHLTeamImpliedTotals = "https://www.numberfire.com/nhl/daily-fantasy/games/implied-team-totals/goalies";

        // NumberFire NHL implied totals rows xpath.
        public static string NumberFireNHLTeamImpliedTotalsRowsXPath = "/html/body/main/div[2]/div[2]/section/div[4]/div[2]/table/tbody/tr";

        // NumberFire NHL implied totals team xpath.
        public static string NumberFireNHLTeamImpliedTotalsTeamXPath = ".//*[@class='team-player__team active']";

        // DailyFantasyFuel NHL url.
        // public static string DailyFantasyFuelNHLURL = "https://www.dailyfantasyfuel.com/nhl/projections/";
        public static string DailyFantasyFuelNHLURL = "https://www.dailyfantasyfuel.com/nhl/projections/draftkings/2024-02-19?slate=18A79";

        // DailyFantasyFuel NHL projection rows xpath.
        public static string DailyFantasyFuelNHLProjectionsRowsXPath = "/html/body/div[2]/div[1]/div[2]/div/div/table/tbody/tr";
    }
}

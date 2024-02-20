using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DFSLineupHelper.Utilities
{
    public class WebScraper
    {
        public static HtmlDocument ScrapeData(string url)
        {
            // Define a temp web client.
            using (WebClient webClient = new WebClient())
            {
                // Save the downloaded data into an HtmlDocument.
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(webClient.DownloadString(url));

                // Return the html document.
                return htmlDocument;
            }
        }
    }
}

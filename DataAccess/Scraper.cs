using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Configuration;

namespace DataAccess
{
    public static class Scraper
    {
        private static List<string> _specialChars = new List<string> { "\r", "\n", "\t", ";", "&nbsp" };
        private static string _url = ConfigurationManager.AppSettings["LadderUrl"];
        private const int _firstTeamRowStartIndex = 1;
        private const int _lastTeamRowStartIndex = 7;

        public static IEnumerable<Tuple<string, int>> GetTeamsWithPointsBroughtToNextTournament()
        {            
            var document = new HtmlWeb().Load(_url);
            HtmlNode table = document.DocumentNode.QuerySelectorAll("table").Single();
            List<HtmlNode> rows = table.QuerySelectorAll("tr").ToList().GetRange(_firstTeamRowStartIndex, _lastTeamRowStartIndex);

            foreach (var row in rows)
            {
                List<HtmlNode> columns = row.QuerySelectorAll("td").ToList();
                string teamName = RemoveSpecialChars(columns[0].InnerText);
                int indexOfPointsBroughtToNextTournamentColumn = columns.Count - 2;
                int pointsBroughtToNextTournament = Int32.Parse(RemoveSpecialChars(columns[indexOfPointsBroughtToNextTournamentColumn].InnerText));
                yield return new Tuple<string, int>(teamName, pointsBroughtToNextTournament);
            }
        }

        private static string RemoveSpecialChars(string input)
        {          
            foreach (string specialChar in _specialChars)
            {
                input = input.Replace(specialChar, "");
            }
            return input;
        }
    }
}
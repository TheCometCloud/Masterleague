using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MasterLeague
{
    public class Retriever
    {
        static readonly string HEROES_URL = "https://api.masterleague.net/heroes/";
        static readonly string MAPS_URL = "https://api.masterleague.net/maps/";
        static readonly string TEAMS_URL = "https://api.masterleague.net/teams/";
        static readonly string REGIONS_URL = "https://api.masterleague.net/regions/";
        static readonly string PATCHES_URL = "https://api.masterleague.net/patches/";
        static readonly string PLAYERS_URL = "https://api.masterleague.net/players/";
        static readonly string TOURNAMENTS_URL = "https://api.masterleague.net/tournaments/";
        static readonly string MATCHES_URL = "https://api.masterleague.net/matches/";
        static readonly string CALENDAR_URL = "https://api.masterleague.net/calendar/";

        static readonly string JSON_FORMAT = "format=json";

        public static string GetAllHeroes()
        {
            string Json = new WebClient().DownloadString(HEROES_URL + "?" + JSON_FORMAT);
            return Json;
        }

        public static string GetAllMaps()
        {
            string Json = new WebClient().DownloadString(MAPS_URL + "?" + JSON_FORMAT);
            return Json;
        }

        public static IList<Team> GetAllTeams()
        {
            IList<Team> teams = new List<Team>();
            
            string Json = new WebClient().DownloadString(TEAMS_URL + "?" + JSON_FORMAT);
            dynamic tmp;
            do
            {
                tmp = JsonConvert.DeserializeObject(Json);

                foreach (dynamic result in tmp.results)
                {
                    Team team = JsonConvert.DeserializeObject<Team>(result.ToString());
                    teams.Add(team);
                }

                if (tmp.next != null)
                {
                    Json = new WebClient().DownloadString(tmp.next.ToString() + "&" + JSON_FORMAT);
                }
            } while (tmp.next != null);

            return teams;
        }
    }
}

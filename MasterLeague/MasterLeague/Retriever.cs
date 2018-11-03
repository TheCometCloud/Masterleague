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
        static readonly string HEROES_URL = "https://api.masterleague.net/heroes/?format=json";
        static readonly string MAPS_URL = "https://api.masterleague.net/maps/?format=json";
        static readonly string TEAMS_URL = "https://api.masterleague.net/teams/?format=json";

        public static string GetAllHeroes()
        {
            string Json = new WebClient().DownloadString(HEROES_URL);
            Console.WriteLine(Json);
            return Json;
        }

        public static string GetAllMaps()
        {
            string Json = new WebClient().DownloadString(MAPS_URL);
            Console.WriteLine(Json);
            return Json;
        }

        public static List<Team> GetAllTeams()
        {
            List<Team> teams = new List<Team>();
            string Json = new WebClient().DownloadString(TEAMS_URL);

            dynamic tmp = JsonConvert.DeserializeObject(Json);
            foreach (dynamic result in tmp.results)
            {
                if (result == null)
                {
                    break;
                }
                else
                {
                    teams.Append(new Team(result));
                }
            }
            return teams;
        }
    }
}

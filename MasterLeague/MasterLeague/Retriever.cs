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

        static readonly string PLUG_TEXT = "Data retrieved from Masterleague.net";

        static readonly string JSON_FORMAT = "format=json";

        public static string GetAllMaps()
        {
            string Json = new WebClient().DownloadString($"{MAPS_URL}?{JSON_FORMAT}");
            return Json;
        }

        public static IList<Team> GetAllTeams()
        {
            IList<Team> teams = new List<Team>();
            
            string Json = new WebClient().DownloadString($"{TEAMS_URL}?{JSON_FORMAT}");
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
                    Json = new WebClient().DownloadString($"{tmp.next.ToString()}&{JSON_FORMAT}");
                }
            } while (tmp.next != null);

            return teams;
        }

        public static IList<Player> GetAllPlayers()
        {
            IList<Player> players = new List<Player>();

            string Json = new WebClient().DownloadString($"{PLAYERS_URL}?{JSON_FORMAT}");
            dynamic tmp;
            do
            {
                tmp = JsonConvert.DeserializeObject(Json);

                foreach (dynamic result in tmp.results)
                {
                    Player player = JsonConvert.DeserializeObject<Player>(result.ToString());
                    players.Add(player);
                }

                if (tmp.next != null)
                {
                    Json = new WebClient().DownloadString($"{tmp.next.ToString()}&{JSON_FORMAT}");
                }
            } while (tmp.next != null);

            return players;
        }

        public static IList<Hero> GetAllHeroes()
        {
            IList<Hero> heroes = new List<Hero>();

            string Json = new WebClient().DownloadString($"{HEROES_URL}?{JSON_FORMAT}");
            dynamic tmp;
            do
            {
                tmp = JsonConvert.DeserializeObject(Json);

                foreach (dynamic result in tmp.results)
                {
                    Hero hero = JsonConvert.DeserializeObject<Hero>(result.ToString());
                    heroes.Add(hero);
                }

                if (tmp.next != null)
                {
                    Json = new WebClient().DownloadString($"{tmp.next.ToString()}&{JSON_FORMAT}");
                }
            } while (tmp.next != null);

            return heroes;
        }

        public static IList<Patch> GetAllPatches()
        {
            IList<Patch> patches = new List<Patch>();

            string Json = new WebClient().DownloadString($"{PATCHES_URL}?{JSON_FORMAT}");
            dynamic tmp;

            tmp = JsonConvert.DeserializeObject(Json);

            foreach (dynamic result in tmp)
            {
                Patch patch = JsonConvert.DeserializeObject<Patch>(result.ToString());
                patches.Add(patch);
            }

            return patches;
        }

        public static IList<Match> GetRecentMatches()
        {
            IList<Match> matches = new List<Match>();

            string Json = new WebClient().DownloadString($"{MATCHES_URL}?{JSON_FORMAT}");
            dynamic tmp = JsonConvert.DeserializeObject(Json);

            foreach (dynamic result in tmp.results)
            {
                Match match = JsonConvert.DeserializeObject<Match>(result.ToString());
                matches.Add(match);
            }

            return matches;
        }

        public static Team GetTeamById(int id)
        {
            string Json = new WebClient().DownloadString($"{TEAMS_URL}{id}?{JSON_FORMAT}");
            Team team = JsonConvert.DeserializeObject<Team>(Json);
            return team;
        }

        public static Match GetMatchById(int id)
        {
            string Json = new WebClient().DownloadString($"{MATCHES_URL}{id}?{JSON_FORMAT}");
            Match match = JsonConvert.DeserializeObject<Match>(Json);
            return match;
        }

        public static DetailedHero GetHeroByID(int id)
        {
            string Json = new WebClient().DownloadString($"{HEROES_URL}{id}?{JSON_FORMAT}");
            DetailedHero hero = JsonConvert.DeserializeObject<DetailedHero>(Json);
            return hero;
        }

        public static string GetMapString(int id)
        {
            string Json = new WebClient().DownloadString($"{MAPS_URL}{id}?{JSON_FORMAT}");
            dynamic tmp = JsonConvert.DeserializeObject(Json);
            return tmp.name.ToString();
        }

        public static string GetRegionString(int id)
        {
            string Json = new WebClient().DownloadString($"{REGIONS_URL}{id}?{JSON_FORMAT}");
            dynamic tmp = JsonConvert.DeserializeObject(Json);
            return tmp.name.ToString();
        }

        public static Patch GetPatchByID(int id)
        {
            string Json = new WebClient().DownloadString($"{PATCHES_URL}{id}?{JSON_FORMAT}");
            Patch patch = JsonConvert.DeserializeObject<Patch>(Json);
            return patch;
        }

        public static Tournament GetTournamentByID(int id)
        {
            string Json = new WebClient().DownloadString($"{TOURNAMENTS_URL}{id}?{JSON_FORMAT}");
            Tournament tournament = JsonConvert.DeserializeObject<Tournament>(Json);
            return tournament;
        }

        public static Player GetPlayerByID(int id)
        {
            string Json = new WebClient().DownloadString($"{PLAYERS_URL}{id}?{JSON_FORMAT}");
            Player player = JsonConvert.DeserializeObject<Player>(Json);
            return player;
        }

        public static IList<Tournament> GetAllTournaments()
        {
            IList<Tournament> tournaments = new List<Tournament>();

            string Json = new WebClient().DownloadString($"{TOURNAMENTS_URL}?{JSON_FORMAT}");
            dynamic tmp;

            tmp = JsonConvert.DeserializeObject(Json);

            foreach (dynamic result in tmp.results)
            {
                Tournament tournament = JsonConvert.DeserializeObject<Tournament>(result.ToString());
                tournaments.Add(tournament);
            }

            return tournaments;
        }
    }
}

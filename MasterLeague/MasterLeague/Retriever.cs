using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Cache;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MasterLeague
{
    public class Retriever
    {
        private readonly HttpRequestCachePolicy Policy;
        private readonly WebClient Client;

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

        public Retriever()
        {
            Policy = new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAge, TimeSpan.FromDays(1));
            Client = new WebClient
            {
                CachePolicy = Policy
            };
        }

        public string GetAllMaps()
        {
            string Json = Client.DownloadString($"{MAPS_URL}?{JSON_FORMAT}");
            return Json;
        }

        public IList<Team> GetAllTeams()
        {
            IList<Team> teams = new List<Team>();
            
            string Json = Client.DownloadString($"{TEAMS_URL}?{JSON_FORMAT}");
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
                    Json = Client.DownloadString($"{tmp.next.ToString()}&{JSON_FORMAT}");
                }
            } while (tmp.next != null);

            return teams;
        }

        public IList<Player> GetAllPlayers()
        {
            IList<Player> players = new List<Player>();

            string Json = Client.DownloadString($"{PLAYERS_URL}?{JSON_FORMAT}");
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
                    Json = Client.DownloadString($"{tmp.next.ToString()}&{JSON_FORMAT}");
                }
            } while (tmp.next != null);

            return players;
        }

        public IList<Hero> GetAllHeroes()
        {
            IList<Hero> heroes = new List<Hero>();

            string Json = Client.DownloadString($"{HEROES_URL}?{JSON_FORMAT}");
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
                    Json = Client.DownloadString($"{tmp.next.ToString()}&{JSON_FORMAT}");
                }
            } while (tmp.next != null);

            return heroes;
        }

        public IList<Patch> GetAllPatches()
        {
            IList<Patch> patches = new List<Patch>();

            string Json = Client.DownloadString($"{PATCHES_URL}?{JSON_FORMAT}");
            dynamic tmp;

            tmp = JsonConvert.DeserializeObject(Json);

            foreach (dynamic result in tmp)
            {
                Patch patch = JsonConvert.DeserializeObject<Patch>(result.ToString());
                patches.Add(patch);
            }

            return patches;
        }

        public IList<Match> GetRecentMatches()
        {
            IList<Match> matches = new List<Match>();

            string Json = Client.DownloadString($"{MATCHES_URL}?{JSON_FORMAT}");
            dynamic tmp = JsonConvert.DeserializeObject(Json);

            foreach (dynamic result in tmp.results)
            {
                Match match = JsonConvert.DeserializeObject<Match>(result.ToString());
                matches.Add(match);
            }

            return matches;
        }

        public Team GetTeamById(int id)
        {
            string Json = Client.DownloadString($"{TEAMS_URL}{id}?{JSON_FORMAT}");
            Team team = JsonConvert.DeserializeObject<Team>(Json);
            return team;
        }

        public Match GetMatchById(int id)
        {
            string Json = Client.DownloadString($"{MATCHES_URL}{id}?{JSON_FORMAT}");
            Match match = JsonConvert.DeserializeObject<Match>(Json);
            return match;
        }

        public DetailedHero GetHeroByID(int id)
        {
            string Json = Client.DownloadString($"{HEROES_URL}{id}?{JSON_FORMAT}");
            DetailedHero hero = JsonConvert.DeserializeObject<DetailedHero>(Json);
            return hero;
        }

        public string GetMapString(int id)
        {
            string Json = Client.DownloadString($"{MAPS_URL}{id}?{JSON_FORMAT}");
            dynamic tmp = JsonConvert.DeserializeObject(Json);
            return tmp.name.ToString();
        }

        public string GetRegionString(int id)
        {
            string Json = Client.DownloadString($"{REGIONS_URL}{id}?{JSON_FORMAT}");
            dynamic tmp = JsonConvert.DeserializeObject(Json);
            return tmp.name.ToString();
        }

        public Patch GetPatchByID(int id)
        {
            string Json = Client.DownloadString($"{PATCHES_URL}{id}?{JSON_FORMAT}");
            Patch patch = JsonConvert.DeserializeObject<Patch>(Json);
            return patch;
        }

        public Tournament GetTournamentByID(int id)
        {
            string Json = Client.DownloadString($"{TOURNAMENTS_URL}{id}?{JSON_FORMAT}");
            Tournament tournament = JsonConvert.DeserializeObject<Tournament>(Json);
            return tournament;
        }

        public Player GetPlayerByID(int id)
        {
            string Json = Client.DownloadString($"{PLAYERS_URL}{id}?{JSON_FORMAT}");
            Player player = JsonConvert.DeserializeObject<Player>(Json);
            return player;
        }

        public IDictionary<Player, Hero> GetPopulatedDraftDict(Draft draft)
        {
            Dictionary<Player, Hero> populated = new Dictionary<Player, Hero>();
            foreach(KeyValuePair<int, int> kv in draft.Picks)
            {
                populated[GetPlayerByID(kv.Key)] = GetHeroByID(kv.Value);
            }
            return populated;
        }

        public IList<Tournament> GetAllTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();

            string Json = Client.DownloadString($"{TOURNAMENTS_URL}?{JSON_FORMAT}");
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

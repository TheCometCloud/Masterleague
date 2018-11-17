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

        public Team GetTeam(int id)
        {
            string Json = Client.DownloadString($"{TEAMS_URL}{id}?{JSON_FORMAT}");
            Team team = JsonConvert.DeserializeObject<Team>(Json);
            return team;
        }

        public Team GetTeam(Draft draft)
        {
            return GetTeam(draft.Team);
        }

        public Match GetMatch(int id)
        {
            string Json = Client.DownloadString($"{MATCHES_URL}{id}?{JSON_FORMAT}");
            Match match = JsonConvert.DeserializeObject<Match>(Json);
            return match;
        }

        public DetailedHero GetHero(int id)
        {
            string Json = Client.DownloadString($"{HEROES_URL}{id}?{JSON_FORMAT}");
            DetailedHero hero = JsonConvert.DeserializeObject<DetailedHero>(Json);
            return hero;
        }

        public DetailedHero GetHero(Hero hero)
        {
            return GetHero(hero.Id);
        }

        public string GetMap(int id)
        {
            string Json = Client.DownloadString($"{MAPS_URL}{id}?{JSON_FORMAT}");
            dynamic tmp = JsonConvert.DeserializeObject(Json);
            return tmp.name.ToString();
        }

        public string GetMap(Match match)
        {
            return GetMap(match.Map);
        }

        public string GetRegion(int id)
        {
            string Json = Client.DownloadString($"{REGIONS_URL}{id}?{JSON_FORMAT}");
            dynamic tmp = JsonConvert.DeserializeObject(Json);
            return tmp.name.ToString();
        }

        public string GetRegion(Player player)
        {
            return GetRegion(player.Region);
        }

        public string GetRegion(Tournament tournament)
        {
            int? id = tournament.Region;
            if (id != null)
            {
                return GetRegion((int) id);
            }
            else
            {
                return null;
            }
        }

        public string GetRegion(Team team)
        {
            return GetRegion(team.Region);
        }

        public Patch GetPatch(int id)
        {
            string Json = Client.DownloadString($"{PATCHES_URL}{id}?{JSON_FORMAT}");
            Patch patch = JsonConvert.DeserializeObject<Patch>(Json);
            return patch;
        }

        public Patch GetPatch(Match match)
        {
            return GetPatch(match.Patch);
        }

        public Tournament GetTournament(int id)
        {
            string Json = Client.DownloadString($"{TOURNAMENTS_URL}{id}?{JSON_FORMAT}");
            Tournament tournament = JsonConvert.DeserializeObject<Tournament>(Json);
            return tournament;
        }

        public Tournament GetTournament(Match match)
        {
            int id = match.Tournament;
            return GetTournament(id);
        }

        public Player GetPlayer(int id)
        {
            string Json = Client.DownloadString($"{PLAYERS_URL}{id}?{JSON_FORMAT}");
            Player player = JsonConvert.DeserializeObject<Player>(Json);
            return player;
        }

        public IList<Hero> GetBans(Draft draft)
        {
            List<Hero> bans = new List<Hero>();
            foreach (int ban in draft.Bans)
            {
                bans.Add(GetHero(ban));
            }
            return bans;
        }

        public IDictionary<Player, Hero> GetPopulatedDraftDict(Draft draft)
        {
            Dictionary<Player, Hero> populated = new Dictionary<Player, Hero>();
            foreach(KeyValuePair<int, int> kv in draft.Picks)
            {
                populated[GetPlayer(kv.Key)] = GetHero(kv.Value);
            }
            return populated;
        }
    }
}

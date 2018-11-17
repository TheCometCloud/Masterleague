using System;
using MasterLeague;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        public static void Main(string[] args)
        {
            Retriever fetcher = new Retriever();

            Match tmp = fetcher.GetMatchById(7772);
            foreach (KeyValuePair<Player, Hero> kv in fetcher.GetPopulatedDraftDict(tmp.Drafts[0]))
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
            foreach (KeyValuePair<Player, Hero> kv in fetcher.GetPopulatedDraftDict(tmp.Drafts[1]))
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
            Console.WriteLine(fetcher.GetPlayerByID(468));
            Console.WriteLine(fetcher.GetTournamentByID(83));
            foreach(Tournament tournament in fetcher.GetAllTournaments())
            {
                Console.WriteLine(tournament);
            }

            Console.WriteLine(fetcher.GetPatchByID(1));
            foreach(Patch patch in fetcher.GetAllPatches())
            {
                Console.WriteLine(patch);
            }

            Console.WriteLine(fetcher.GetAllMaps());

            Console.WriteLine(fetcher.GetHeroByID(7));
            foreach(Hero hero in fetcher.GetAllHeroes())
            {
                Console.WriteLine(hero);
            }

            Console.WriteLine(fetcher.GetTeamById(95));
            Console.WriteLine(fetcher.GetMatchById(7772));
            Console.WriteLine(fetcher.GetMapString(3));
            Console.WriteLine(fetcher.GetRegionString(4));

            foreach(Team team in fetcher.GetAllTeams())
            {
                Console.WriteLine(team);
            }

            foreach(Match match in fetcher.GetRecentMatches())
            {
                Console.WriteLine(match);
            }

            foreach (Player player in fetcher.GetAllPlayers())
            {
                Console.WriteLine(player);
            }
            Console.ReadLine();
        }
    }
}

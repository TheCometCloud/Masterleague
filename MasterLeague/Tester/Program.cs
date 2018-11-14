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
            Console.WriteLine(Retriever.GetTournamentByID(83));
            foreach(Tournament tournament in Retriever.GetAllTournaments())
            {
                Console.WriteLine(tournament);
            }

            Console.WriteLine(Retriever.GetPatchByID(1));
            foreach(Patch patch in Retriever.GetAllPatches())
            {
                Console.WriteLine(patch);
            }

            Console.WriteLine(Retriever.GetAllMaps());

            Console.WriteLine(Retriever.GetHeroByID(7));
            foreach(Hero hero in Retriever.GetAllHeroes())
            {
                Console.WriteLine(hero);
            }

            Console.WriteLine(Retriever.GetTeamById(95));
            Console.WriteLine(Retriever.GetMatchById(7772));
            Console.WriteLine(Retriever.GetMapString(3));
            Console.WriteLine(Retriever.GetRegionString(4));

            foreach(Team team in Retriever.GetAllTeams())
            {
                Console.WriteLine(team);
            }

            foreach(Match match in Retriever.GetRecentMatches())
            {
                Console.WriteLine(match);
            }

            foreach (Player player in Retriever.GetAllPlayers())
            {
                Console.WriteLine(player);
            }
            Console.ReadLine();
        }
    }
}

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
            Console.WriteLine(Retriever.GetAllMaps());
            Console.WriteLine();
            Console.WriteLine(Retriever.GetAllHeroes());

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

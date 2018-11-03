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

            foreach(Team team in Retriever.GetAllTeams())
            {
                Console.WriteLine(team);
            }
            Console.ReadLine();
        }
    }
}

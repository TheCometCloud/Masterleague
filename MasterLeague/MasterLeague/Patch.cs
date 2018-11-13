using System;
using System.Collections.Generic;
using System.Text;

namespace MasterLeague
{
    public class Patch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime From_Date { get; set; }
        public DateTime To_Date { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterLeague
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Region { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, ID: {Id}, Region: {Region}, Url: {Url}";
        }
    }
}

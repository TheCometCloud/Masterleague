using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterLeague
{
    public class Draft
    {
        public int Team { get; set; }
        public bool Won { get; set; }
        public List<int> Bans { get; set; }
        public JArray picks { get; set; }

        public IDictionary<int, int> Picks
        {
            get
            {
                Dictionary<int,int> holder = new Dictionary<int,int>();
                foreach (dynamic pick in picks)
                {
                    holder[pick.player.ToObject<int>()] = pick.hero.ToObject<int>();
                }
                return holder;
            }
        }

        public override string ToString()
        {
            List<string> tmp = new List<string>();
            foreach(KeyValuePair<int, int> pick in Picks)
            {
                tmp.Add($"{pick.Key.ToString()}: {pick.Value.ToString()}");
            }
            return string.Join(", ", tmp);
        }
    }
}

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

        public List<int> Picks
        {
            get
            {
                List<int> holder = new List<int>();
                foreach (dynamic pick in picks)
                {
                    holder.Add(pick.hero.ToObject<int>());
                }
                return holder;
            }
        }

        public override string ToString()
        {
            List<string> tmp = new List<string>();
            foreach(int i in Picks)
            {
                tmp.Add(i.ToString());
            }
            return string.Join(", ", tmp);
        }
    }
}

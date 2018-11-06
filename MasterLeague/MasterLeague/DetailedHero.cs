using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterLeague
{
    public class DetailedHero : Hero
    {
        public dynamic talents { get; set; }

        public List<Talent> Talents
        {
            get
            {
                List<Talent> temp = new List<Talent>();
                foreach (dynamic tal in talents)
                {
                    temp.Add(JsonConvert.DeserializeObject<Talent>(tal));
                }
                return temp;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterLeague
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Patch { get; set; }
        public int Tournament { get; set; }
        public int Stage { get; set; }
        public string Round { get; set; }
        public int Series { get; set; }
        public string SeriesFormat { get; set; }
        public int Game { get; set; }
        public int Map { get; set; }
        public int Duration { get; set; }
        public string Url { get; set; }
        public dynamic drafts { get; set; }

        public Draft[] Drafts
        {
            get
            {
                Draft[] holder = new Draft[]
                {
                    JsonConvert.DeserializeObject<Draft>(drafts[0].ToString()),
                    JsonConvert.DeserializeObject<Draft>(drafts[1].ToString())
                };
                return holder;
            }
        }

        public override string ToString()
        {
            return $"{Date.ToString()} {Round} {Drafts[0]} vs. {Drafts[1]}";
        }
    }
}

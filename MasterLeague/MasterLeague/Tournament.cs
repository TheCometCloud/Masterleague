using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;


namespace MasterLeague
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int? Region { get; set; }
        public string Url { get; set; }
        public JArray stages { get; set; }
        
        public List<Stage> Stages
        {
            get
            {
                List<Stage> holder = new List<Stage>();
                foreach(dynamic stage in stages)
                {
                    holder.Add(stage.toObject<Stage>());
                }
                return holder;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

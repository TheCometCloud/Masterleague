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
        public dynamic Logo { get; set; }

        public string SmallLogo
        {
            get { return Logo.small; }
        }

        public string BigLogo
        {
            get { return Logo.big; }
        }

        public string MediumLogo
        {
            get { return Logo.medium; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

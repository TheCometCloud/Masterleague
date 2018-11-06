using System;
using System.Collections.Generic;
using System.Text;

namespace MasterLeague
{
    public class Talent
    {
        public int Tier { get; set; }
        public int Choice { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public dynamic Icon { get; set; }

        public string SmallIcon
        {
            get
            {
                return Icon.small;
            }
        }

        public string MediumIcon
        {
            get
            {
                return Icon.medium;
            }
        }

        public override string ToString()
        {
            return $"{Name}: {Description}. {SmallIcon}";
        }
    }
}

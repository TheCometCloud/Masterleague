using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterLeague
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public string Url { get; set; }
        public dynamic Portrait { get; set; }

        public string SmallPortrait
        {
            get
            {
                return Portrait.small;
            }
        }

        public string MediumPortrait
        {
            get
            {
                return Portrait.medium;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Role} {SmallPortrait}";
        }
    }
}
